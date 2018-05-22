var i = 0;

function Next() {
	    var images = document.querySelectorAll("#photo img");
		var oNext = document.getElementById("next");
		images[i].className = '';
		i++;
		if (i >= images.length) {
			i = 0;
		}

		images[i].className = 'showed';

	}
function Prev() {
		var images = document.querySelectorAll("#photo img");
		var oPrev = document.getElementById("prev");
		images[i].className = '';
		i--;
		if (i < 0) {
			i = images.length - 1;
		}
		images[i].className = 'showed';

	}

setInterval(Next(), 1000);



/*$(window).on('scroll', function(){
	if($(window).scrollTop()) {
		$('nav').addClass('black');
	} 
	else {
		$('nav').removeClass('black');
	}
})


$(window).scroll(function (){ 
		 	$(' .mov1').each(function (){ 
		 		var imagePos = $(this).offset().top; 
		 		var topOfWindow = $(window).scrollTop(); 
		 		if (imagePos < topOfWindow+550) { 
		 			$(this).addClass('slideInUp'); 
		 		} 
		 	}); 
		 });﻿
*/

