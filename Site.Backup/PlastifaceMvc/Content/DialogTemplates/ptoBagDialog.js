	function initializeDialog(){
		// data bindings:
		var gussetSize = theProduct.HasGusset ? theProduct.Gusset.Size : 0;
		var gussetOrientation = theProduct.HasGusset ? theProduct.Gusset.Orientation : 1;

		$("*[data='width']").val(theProduct.Width).blur(function(){ theProduct.Width = parseFloat($(this).val()); });
		$("*[data='gussetSize']").val(gussetSize).blur(function() { theProduct.HasGusset ? theProduct.Gusset.Size = parseFloat($(this).val()) : void(0); });
		$("*[data='gussetOrientation']").val(gussetOrientation).change(function() { theProduct.HasGusset ? theProduct.Gusset.Orientation = $(this).val() : void(0); });
		$("*[data='length']").val(theProduct.Length).blur(function(){ theProduct.Length = parseFloat($(this).val()); });
		$("*[data='gauge']").val(theProduct.Gauge).blur(function(){ theProduct.Gauge = parseFloat($(this).val()); });

		doToggleGusset(true);
		
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
		$('#toggleGusset').click(function () {
			theProduct.HasGusset ^= true;
			theProduct.Gusset = theProduct.HasGusset ? { Size: 0, Orientation: 1 } : null;
			doToggleGusset();
		});
	}

	function doToggleGusset(immediate) {
		var gussetContainer = $("td[col='gusset'] span");
		if (immediate) {
			gussetContainer.css('display', theProduct.HasGusset ? 'block' : 'none');
		}
		else {
			$("td[col='gusset'] span").animate(
				{ width: theProduct.HasGusset ? 'show' : 'hide' }, { duration: 'fast' }
			);
		}

		$('#toggleGusset').text(theProduct.HasGusset?'Remove Gusset':'Add Gusset');
	}
	
	// Helper functions:
	function isNan(value) { return (!value) && (value!=0) }
