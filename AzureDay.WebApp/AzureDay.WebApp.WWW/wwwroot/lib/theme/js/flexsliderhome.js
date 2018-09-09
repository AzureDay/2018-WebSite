$(document).ready(function () {
	$('#home-slider').flexslider({
		pauseOnHover: true,    
		slideshow: true,                //Boolean: Animate slider automatically
		slideshowSpeed: 6000,           //Integer: Set the speed of the slideshow cycling, in milliseconds
		animationSpeed: 600,
		animation: "fade",              //String: Select your animation type, "fade" or "slide"
		easing: "swing",               //{NEW} String: Determines the easing method used in jQuery transitions. jQuery easing plugin is supported!
		direction: "horizontal",
		controlNav: true,               //Boolean: Create navigation for paging control of each clide? Note: Leave true for manualControls usage
		useCSS: true,                   //{NEW} Boolean: Slider will use CSS3 transitions if available
		touch: true, 
		directionNav: true
	});
});