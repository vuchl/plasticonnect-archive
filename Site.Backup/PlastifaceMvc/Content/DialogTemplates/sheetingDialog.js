	function initializeDialog(){
		// data bindings:
		$("*[data='width']").val(theProduct.Width).blur(function(){ theProduct.Width = parseFloat($(this).val()); });
		$("*[data='gauge']").val(theProduct.Gauge).blur(function(){ theProduct.Gauge = parseFloat($(this).val()); });


		//$("*[data='gussetOrientation']").val(theProduct.gusset.orientation).change(function(){ theProduct.gusset.orientation = $(this).val(); });
		//doToggleGusset();
		
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
	}
	
	// Helper functions:
	function isNan(value) { return (!value) && (value!=0) }
