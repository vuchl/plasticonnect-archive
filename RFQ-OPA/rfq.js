var theProduct;
var validationRules;

var $ = jQuery;
//-------------------------------------------------------------------------
$(document).ready(function () {
	$('#porpertyForm').validate();
});

//-------------------------------------------------------------------------
$(document).ready(function () {

	$('#submit').click(function () {
		window.dataSource = [];
		$('#mainRequisition tbody').each(function () {
			window.dataSource[window.dataSource.length] = $(this).data('item');
		});

		$('#dump').html(JSON.stringify(window.dataSource));
	});
});
//-------------------------------------------------------------------------
$(document).ready(function () {
	$('div.actions').fadeTo(1, 0.2)
		.hover(function () { $(this).fadeTo(100, 1); }, function () { $(this).fadeTo(300, 0.1); });

	for (var i = 0; i < dataSource.length; ++i) {
		var newRow = $(theRowTemplate);
		newRow.data('item', dataSource[i]);
		initializeRow(newRow);
		$('#mainRequisition').append(newRow);
	}

	$('#productSelector').change(function () {
		var select = $(this);
		$.ajax({
			url: 'New' + select.val() + '.html',
			cache: false,
			success: function (obj) {
				var newRow = $(theRowTemplate);
				newRow.data('item', eval(obj));
				initializeRow(newRow);

				newRow.find('td').wrapInner('<div style="display: block;" />');
				newRow.find('td > div').hide();
				$('#mainRequisition').append(newRow);
				newRow.find('td > div').slideDown(400, function () {
					var $set = $(this);
					$set.replaceWith($set.contents());
				});

				select.val('-1');
			}
		});
	});
});
	
function addQuantityTr(row, qtyIdx) {
	var last = row.find('tr').eq(-2);
	var newQty = $(theQuantityRowTemplate);
	last.before(newQty);
	$(newQty)
		.find("[data='quantity']")
		.blur(function () { row.data('item').quantityList[qtyIdx].quantity = $(this).val(); })
		.val(row.data('item').quantityList[qtyIdx].quantity);
		//.validate();
	row.find("td[rowspan]").attr('rowspan', row.find('>tr').size()-2);	
}
	
function initializeQuantities(row){
	var numQty = row.data('item').quantityList.length;
	var qty = row.data('item').quantityList[0].quantity;
	row.find("[data='quantity']:first")
		.blur(function () { row.data('item').quantityList[0].quantity = $(this).val() == 'Min' ? -1 : $(this).val(); })
		.val(qty == -1 ? 'Min' : qty);
		
	if(qty==-1)	row.find("[data='quantity']:first").attr('readonly', 'readonly');
	else		row.find("[data='quantity']:first").removeAttr('readonly');
			
	row.find("[data='quantity']:gt(0)").closest('tr').remove(); // in case there is any (happens when dupliate pressed)
		
	var i = 0;
		
	while( ++i < numQty ) {
		addQuantityTr(row, i);
	}
}
	
function initializeRow(row) {
	row.find("[data='description']").text(window.productToString(row.data('item').product));
	row.find("[data='unitPrice']").val(row.data('item').unitPrice);
	row.find("[data='uom']").change(function(){row.data('item').uom = $(this).val();}).val(row.data('item').uom);
	initializeQuantities(row);

	row.find('div.actions').fadeTo(1, 0.1)
		.hover(function() { $(this).fadeTo(100, 1); }, function() { $(this).fadeTo(300, 0.1); });

	row.find("*[action='duplicate']").click(function () {
		var itemContainer = $(this).closest('tbody');
		var clone = itemContainer.clone(false);
		clone.data('item', JSON.parse(JSON.stringify(itemContainer.data('item'))));
		initializeRow(clone);
		clone.find('td').wrapInner('<div style="display: block;" />');
		clone.find('td > div').hide();
		itemContainer.after(clone);
		clone.find('td > div').slideDown(400, function () {
			var $set = $(this);
			$set.replaceWith($set.contents());
		});
	});

	row.find("*[action='delete']").click(function () {
		var itemContainer = $(this).closest('tbody');
		if (confirm('Are you sure to delete this row?')) {
			itemContainer.find('td, th').wrapInner('<div style="display: block;" />');
			itemContainer.fadeOut(200);
			itemContainer.find('td>div, th>div').slideUp(400, function () {
				itemContainer.remove();
			});
		}
	});

	row.find("*[action='moveUp']").click(function () {
		var itemContainer = $(this).closest('tbody');
		var prev = itemContainer.prev();

		itemContainer.find('td, th').wrapInner('<div style="display: block;" />');
		itemContainer.fadeOut(200);
		itemContainer.find('td>div, th>div').slideUp(500, function () {
			prev.before(itemContainer);

			itemContainer.fadeIn(200);
			itemContainer.find('td>div, th>div').slideDown(500, function () {
				$(this).replaceWith($(this).contents());
			});
		});
	});

	row.find("*[action='moveDown']").click(function () {
		var itemContainer = $(this).closest('tbody');
		var next = itemContainer.next();

		itemContainer.find('td, th').wrapInner('<div style="display: block;" />');
		itemContainer.fadeOut(200);
		itemContainer.find('td>div, th>div').slideUp(500, function () {
			next.after(itemContainer);

			itemContainer.fadeIn(200);
			itemContainer.find('td>div, th>div').slideDown(500, function () {
				$(this).replaceWith($(this).contents());
			});
		});
	});

	row.find("*[action='addQuantity']").click(function () {
		var itemContainer = $(this).closest('tbody');
		var size = itemContainer.data('item').quantityList.length;
		if (itemContainer.data('item').quantityList[0].quantity == -1) {
			itemContainer.find("[data='quantity']:first").val('').removeAttr('readonly');
			itemContainer.data('item').quantityList[0].quantity = '';
		}
		else {
			itemContainer.data('item').quantityList[size] = { quantity: '', unitPrice: '' };
			addQuantityTr(itemContainer, size);
		}
	});

	row.find("*[action='minimumQuantity']").click(function () {
		var itemContainer = $(this).closest('tbody');
		itemContainer.find("[data='quantity']:gt(0)").closest('tr').remove();

		itemContainer.data('item').quantityList.length = 1;
		itemContainer.data('item').quantityList[0] = { quantity: -1, unitPrice: '' };
		itemContainer.find("[data='quantity']:first").val('Min').attr('readonly', 'true');
		itemContainer.find("td[rowspan]").attr('rowspan', row.find('>tr').size() - 2);
	});
		
	row.find("*[action='deleteQuantity']").click(function(){
		var itemContainer = $(this).closest('tbody');
		var numRows = itemContainer.find('>tr').size();
		if(numRows == 4) return;
			
		row.data('item').quantityList.pop();
		itemContainer.find('tr').eq(-3).remove();
		itemContainer.find("td[rowspan]").attr('rowspan', itemContainer.find('>tr').size()-2);
	});

	row.find("*[action='change']").click(function () {
		var itemContainer = $(this).closest('tbody');
		var itemDescriptor = itemContainer.find('*.itemDescriptor');
		var item = itemContainer.data('item');
		var product = item.product;
		theProduct = product; // bridge to the product dialog
		var url = product.type + "Dialog.html";
		var dialogScript = product.type + "Dialog.js";

		var dialogProps = {
			resizable: false,
			modal: true,
			width: window.dialogWidths[product.type],
			close: function () { itemDescriptor.fadeOut('fast', function () { $(this).text(window.productToString(product)); }).fadeIn(); },
			buttons: { "Ok": function () { $(this).dialog('close'); } }
		};

		$.ajax({
			url: url,
			cache: false,
			success: function (html) {
				$("#productDialog").empty().append(html).dialog(dialogProps);
				$(".ui-dialog-titlebar").hide();

				$.getScript(dialogScript, function (data, textStatus) {
					initializeDialog();
				});
			}
		});
	});
};

	
var theQuantityCell = "<input data='quantity' type='text' class='simple number' style='width: 50px;' maxlength='6' /></td>";
var theQuantityRowCore = "<td class='quantity'>" + theQuantityCell + "<td class='unitPrice'>&nbsp;</td>";
var theQuantityRowTemplate = "<tr>" + theQuantityRowCore + "</tr>"; 
	
var theRowTemplate = "\
<tbody>\
	<tr>\
		<th>Product</th>\
		<th>UOM</th>\
		<th>Qty</th>\
		<th>Unit Price</th>\
	</tr>\
	<tr class='requisitionItem'>\
		<td rowspan='2' class='product'>\
			<span data='description' class='itemDescriptor'></span><br/>\
			<div class='actions'>Item Specific Actions: \
				<a action='delete'><img src='images/delete.png' alt='delete' /></a>\
				<a action='moveUp'><img src='images/up.png' alt='move up' /></a>\
				<a action='moveDown'><img src='images/down.png' alt='move down' /></a>\
				<a action='duplicate'><img src='images/duplicate.png' alt='duplicate' /></a>\
				<a action='change'><img src='images/modify.png' alt='modify' /></a>\
			</div>\
		</td>\
		<td rowspan='2' class='uom'><select data='uom'><option>M</option><option>Rolls</option><option>Lbs</option></select></td>" +
		theQuantityRowCore + "\
	</tr>\
	<tr>\
		<td colspan='2'>\
			<div class='actions'>Quantity Actions: \
			<a action='addQuantity' title='Add a new quantity'><img src='images/addQuantity.png' alt='AddQuantity' /></a>\
			<a action='minimumQuantity' title='Ask for the minimum quantity'><img src='images/minimum.png' alt='MinimumQuantity' /></a>\
			<a action='deleteQuantity' title='Delete the last quantity'><img src='images/deleteQuantity.png' alt='DeleteQuantity' /></a>\
			</div>\
		</td>\
	</tr>\
	<tr><td colspan='4' class='gap'>&nbsp;</td></tr>\
</tbody>\
";
