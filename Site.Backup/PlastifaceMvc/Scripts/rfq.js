var theProduct;
var validationRules;

var $ = jQuery;
//-------------------------------------------------------------------------
$(document).ready(function () {
	theRowTemplate = $("tbody#rowTemplate");
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

	$.each(dataSource, function (i, val) {
		var newRow = theRowTemplate.clone();
		newRow.removeAttr("id");
		newRow.data('item', val);
		initializeRow(newRow);
		$('#mainRequisition').append(newRow);
	});

	$('#productSelector').change(function () {
		var select = $(this);
		$.ajax({
			url: '/Rfq/GetNewItem?type=' + select.val(),
			cache: false,
			success: function (obj) {
				var newRow = theRowTemplate.clone();
				newRow.removeAttr("id");
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

	$('#testAddNew').click(function () {
		var pType = 'PtoBag';
		$.ajax({
			url: '/Rfq/GetNewItem?type=' + pType,
			cache: false,
			success: function (obj) {
				var item = eval(obj);
				theProduct = item.Product;  // bridge to the product dialog
				var url = '/Content/DialogTemplates/' + theProduct.ProductType + "Dialog.html";
				var dialogScript = '/Content/DialogTemplates/' + theProduct.ProductType + "Dialog.js";

				var dialogProps = {
					resizable: false,
					modal: true,
					width: window.dialogWidths[theProduct.ProductType],
					close: function () {
					},
					buttons: {
						"Ok": function () {
							var newRow = theRowTemplate.clone();
							newRow.removeAttr("id");
							newRow.data('item', item);
							initializeRow(newRow);

							newRow.find('td').wrapInner('<div style="display: block;" />');
							newRow.find('td > div').hide();
							$('#mainRequisition').append(newRow);
							newRow.find('td > div').slideDown(400, function () {
								var $set = $(this);
								$set.replaceWith($set.contents());
							});
							$(this).dialog('close');
						},
						"Cancel": function () { $(this).dialog('close'); }
					}
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

			}
		});
	});
});
	
function addQuantityTr(row, qtyIdx) {
	var last = row.find('tr').eq(-2);
	var newQty = $("tr#quantityRowTemplate").clone();
	newQty.removeAttr("id");
	last.before(newQty);
	$(newQty)
		.find("[data='quantity']")
		.blur(function () { row.data('item').QuantityList[qtyIdx] = $(this).val(); })
		.val(row.data('item').QuantityList[qtyIdx]);
		//.validate();
	row.find("td[rowspan]").attr('rowspan', row.find('>tr').size()-2);	
}
	
function initializeQuantities(row){
	var numQty = row.data('item').QuantityList.length;
	var qty = row.data('item').QuantityList[0];
	row.find("[data='quantity']:first")
		.blur(function () { row.data('item').QuantityList[0] = $(this).val() == 'Min' ? -1 : $(this).val(); })
		.val(qty == -1 ? 'Min' : qty);
		
	if(qty==-1)	row.find("[data='quantity']:first").attr('readonly', 'readonly');
	else		row.find("[data='quantity']:first").removeAttr('readonly');
			
	row.find("[data='quantity']:gt(0)").closest('tr').remove(); // in case there is any (happens when duplicate pressed)
		
	var i = 0;
		
	while( ++i < numQty ) {
		addQuantityTr(row, i);
	}
}
	
function initializeRow(row) {
	row.find("[data='description']").text(row.data('item').Product.ToString);
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
		var size = itemContainer.data('item').QuantityList.length;
		if (itemContainer.data('item').QuantityList[0] == -1) {
			itemContainer.find("[data='quantity']:first").val('').removeAttr('readonly');
			itemContainer.data('item').QuantityList[0] = '';
		}
		else {
			itemContainer.data('item').QuantityList[size] = '';
			addQuantityTr(itemContainer, size);
		}
	});

	row.find("*[action='minimumQuantity']").click(function () {
		var itemContainer = $(this).closest('tbody');
		itemContainer.find("[data='quantity']:gt(0)").closest('tr').remove();

		itemContainer.data('item').QuantityList.length = 1;
		itemContainer.data('item').QuantityList[0] = -1;
		itemContainer.find("[data='quantity']:first").val('Min').attr('readonly', 'true');
		itemContainer.find("td[rowspan]").attr('rowspan', row.find('>tr').size() - 2);
	});
		
	row.find("*[action='deleteQuantity']").click(function(){
		var itemContainer = $(this).closest('tbody');
		var numRows = itemContainer.find('>tr').size();
		if(numRows == 4) return;
			
		row.data('item').QuantityList.pop();
		itemContainer.find('tr').eq(-3).remove();
		itemContainer.find("td[rowspan]").attr('rowspan', itemContainer.find('>tr').size()-2);
	});

	row.find("*[action='change']").click(function () {
		var itemContainer = $(this).closest('tbody');
		var itemDescriptor = itemContainer.find('*.itemDescriptor');
		var item = itemContainer.data('item');
		var product = item.Product;
		theProduct = product; // bridge to the product dialog
		var url = '/Content/DialogTemplates/' + product.ProductType + "Dialog.html";
		var dialogScript = '/Content/DialogTemplates/' + product.ProductType + "Dialog.js";

		var dialogProps = {
			resizable: false,
			modal: true,
			width: window.dialogWidths[product.ProductType],
			close: function() {
			},
			buttons: {
				"Ok": function() {
					itemDescriptor
						.fadeOut('fast', function() { $(this).text(product.ToString); })
						.fadeIn();
					$(this).dialog('close');
				}
			}
		};

		$.ajax({
			url:  '\/Rfq\/Test',  // url,
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
