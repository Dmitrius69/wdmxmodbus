function stripBorder_2_yp5ac69a6f70806(object) {
	object.each(function() {
		if( parseInt(jQuery(this).width() ) > 0) {
			jQuery(this).width( 
				parseInt( 
					jQuery(this).width() ) - 
					parseInt(jQuery(this).css("border-left-width")) - 
					parseInt(jQuery(this).css("border-right-width")) 
			);
			}
		else {
		jQuery(this).css("border-left-width", "0px");
		jQuery(this).css("border-right-width", "0px");
		}
	});
}
function stripPadding_2_yp5ac69a6f70806(object) {
	object.each(function() { 
		jQuery(this).width( 
		parseInt( jQuery(this).width() ) - 
		parseInt(jQuery(this).css("padding-left")) - 
		parseInt(jQuery(this).css("padding-left")) 
		);
	});
}

function strip_results_2_yp5ac69a6f70806() {
	stripPadding_2_yp5ac69a6f70806( jQuery("#yop-poll-container-2_yp5ac69a6f70806 .yop_poll_li_result-2_yp5ac69a6f70806") );   
	stripBorder_2_yp5ac69a6f70806(  jQuery("#yop-poll-container-2_yp5ac69a6f70806 .yop-poll-result-bar-2_yp5ac69a6f70806") );
}

jQuery(document).ready(function(e) {
	if(typeof window.strip_results_2_yp5ac69a6f70806 == "function")  
		strip_results_2_yp5ac69a6f70806();
	if(typeof window.tabulate_answers_2_yp5ac69a6f70806 == "function") 
		tabulate_answers_2_yp5ac69a6f70806();
	if(typeof window.tabulate_results_2_yp5ac69a6f70806 == "function")  
		tabulate_results_2_yp5ac69a6f70806();
});

function equalWidth_2_yp5ac69a6f70806(obj, cols, findWidest ) {
	findWidest  = typeof findWidest  !== "undefined" ? findWidest  : false;
	if ( findWidest ) {
		obj.each(function() {
			var thisWidth = jQuery(this).width();
			width = parseInt(thisWidth / cols); 
			jQuery(this).width(width);    
			jQuery(this).css("float", "left");    
		});
	}
	else {
		var widest = 0;
		obj.each(function() {
			var thisWidth = jQuery(this).width();
			if(thisWidth > widest) {
				widest = thisWidth; 
			}    
		});
		width = parseInt( widest / cols); 
		obj.width(width);    
		obj.css("float", "left");    
	}    
}

function tabulate_answers_2_yp5ac69a6f70806() {
	equalWidth_2_yp5ac69a6f70806( jQuery("#yop-poll-container-2_yp5ac69a6f70806 .yop-poll-li-answer-2_yp5ac69a6f70806"), 1 );
	//equalWidth_2_yp5ac69a6f70806( jQuery("#yop-poll-container-2_yp5ac69a6f70806 .yop-poll-li-answer-2_yp5ac69a6f70806 .yop-poll-results-bar-2_yp5ac69a6f70806 div "), 1, true );
}

function tabulate_results_2_yp5ac69a6f70806() {
	equalWidth_2_yp5ac69a6f70806( jQuery("#yop-poll-container-2_yp5ac69a6f70806 .yop-poll-li-result-2_yp5ac69a6f70806"), 1 );
	//equalWidth_2_yp5ac69a6f70806( jQuery("#yop-poll-container-2_yp5ac69a6f70806 .yop-poll-li-result-2_yp5ac69a6f70806 .yop-poll-results-bar-2_yp5ac69a6f70806 div "), 1, true );
	}

jQuery(document).ready(function(){
	runOnPollStateChange_2_yp5ac69a6f70806();
});

function runOnPollStateChange_2_yp5ac69a6f70806() {

};