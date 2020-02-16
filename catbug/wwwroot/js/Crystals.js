function Crystals(canvas, distorted)
{
	this.canvas = canvas;
	this.distorted = distorted;
	this.ctx = this.canvas.getContext("2d");

	this.canvas.width = document.documentElement.clientWidth;
	this.canvas.height = document.documentElement.clientHeight;

	window.addEventListener('resize', function(){
		this.canvas.width = document.documentElement.clientWidth;
		this.canvas.height = document.documentElement.clientHeight;
	});

	function randomize(min, max)
	{
		return Math.random() * (max - min) + min;
	}

	function drawRotatedRect(x,y,width,height,degrees)
	{

		// first save the untranslated/unrotated context
		this.ctx.save();

		this.ctx.beginPath();
		// move the rotation point to the center of the rect
		this.ctx.translate( x+width/2, y+height/2 );
		// rotate the rect
		this.ctx.rotate(degrees*Math.PI/180);

		// draw the rect on the transformed context
		// Note: after transforming [0,0] is visually [x,y]
		//       so the rect needs to be offset accordingly when drawn
		this.ctx.rect( -width/2, -height/2, width,height);

		this.ctx.fillStyle = 'rgba(255, 255, 255, .05)';
		this.ctx.fill();

		// restore the context to its untranslated/unrotated state
		this.ctx.restore();

	}

	var elements = [];
	var timer = 0;
	var i = 0;

	function createStripe(x)
	{

		var push = 0;

		while(push < this.canvas.height)
		{
			if(elements[i] == null)
			{
				elements[i] = [];
				elements[i]['size'] = randomize(100, 200);
				elements[i]['cool'] = randomize(100, 200);
				elements[i]['start'] = randomize(0, 360);
				elements[i]['offset'] = randomize(-100, elements[i]['size']/2);
				elements[i]['push'] = randomize(50, 100);
			}
			drawRotatedRect(x + elements[i]['offset'] + Math.sin(elements[i]['start'] + timer/elements[i]['cool'])*elements[i]['size']/10-elements[i]['size']/2, push, elements[i]['size'], elements[i]['size'], 45);

			push += elements[i]['size'] + elements[i]['push'];

			i++;
		}
	}

	setInterval(function(){

		this.ctx.clearRect(0, 0, this.canvas.width, this.canvas.height);
		this.ctx.beginPath();

		i = 0;
		if(distorted)
		{
			createStripe(0, i);
			createStripe(this.canvas.width, i);
			createStripe(this.canvas.width/4*3, i);
			createStripe(this.canvas.width/4, i);
		}
		else
		{
			createStripe(0, i);
			createStripe(this.canvas.width, i);
		}

		timer++;

	}, 16.66);

}