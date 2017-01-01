	function initializeDialog(){
		// data bindings:
		$("*[data='width']").val(theProduct.width).blur(function(){ theProduct.width = parseFloat($(this).val()); });
		$("*[data='gussetSize']").val(theProduct.gusset.size).blur(function(){ theProduct.gusset.size = parseFloat($(this).val()); });
		$("*[data='gussetOrientation']").val(theProduct.gusset.orientation).change(function(){ theProduct.gusset.orientation = $(this).val(); });
		$("*[data='length']").val(theProduct.length).blur(function(){ theProduct.length = parseFloat($(this).val()); });
		$("*[data='gauge']").val(theProduct.gauge.size).blur(function(){ theProduct.gauge.size = parseFloat($(this).val()); });
		doToggleGusset();
		
		// dataDesctiptions:
		$("*[dataDescription]").focus(function(){
			var status = $(this).closest(".fieldset").find("div.status span");
			var text = $(this).attr('dataDescription');
			status.fadeTo('fast', 0.01, function(){
				status.html(text);
				status.fadeTo('fast', 1);
			});
		}).blur(function () {
			var status = $(this).closest(".fieldset").find("div.status span");
			status.fadeTo('fast', 0.01);
		});
		
		// togglling gusset:
		$('#toggleGusset').click(function(){
			theProduct.hasGusset ^= true;
			
			doToggleGusset();
		});
	}
	
	function doToggleGusset(show) {
		$("td[col='gusset'] span").animate(
			{width: theProduct.hasGusset?'show':'hide'}, {duration: 'fast'}
		);
		$('#toggleGusset').text(theProduct.hasGusset?'Remove Gusset':'Add Gusset');
	}
	
	function parseProduct(){
		return theProduct.toString();
	}

	// Helper functions:
	function isNan(value) { return (!value) && (value!=0) }
