function Shapes(canvas, amount)
{
	this.canvas = canvas;
	this.amount = amount;
	this.ctx = this.canvas.getContext("2d");

	this.canvas.width = document.documentElement.clientWidth;
	this.canvas.height = document.documentElement.clientHeight;

	window.addEventListener('resize', function(){
		this.canvas.width = document.documentElement.clientWidth;
		this.canvas.height = document.documentElement.clientHeight;
		elements = [];
	});

	function randomize(min, max)
	{
		return Math.random() * (max - min) + min;
	}

	function drawRotatedRect(x, y, size, degrees, shape)
	{

		// first save the untranslated/unrotated context
		this.ctx.save();

		this.ctx.beginPath();
		// move the rotation point to the center of the rect
		this.ctx.translate( x+size/2, y+size/2 );
		// rotate the rect
		this.ctx.rotate(degrees*Math.PI/180);

		this.ctx.lineWidth="7";
		this.ctx.strokeStyle="white";

		// Make random shape
		switch(shape)
		{
			case 0:
				this.ctx.rect(-size/2, -size/2, size, size);
				break;
			case 1:
				this.ctx.arc(0, 0, size/2, 0, 2*Math.PI);
				break;
			case 2:
				var h = size * (Math.sqrt(3)/2);
				this.ctx.moveTo(0, -h / 2);
				this.ctx.lineTo( -size / 2, h / 2);
				this.ctx.lineTo(size / 2, h / 2);
				this.ctx.lineTo(0, -h / 2);
		}

		this.ctx.closePath();
		this.ctx.stroke();

		// restore the context to its untranslated/unrotated state
		this.ctx.restore();

	}

	var elements = [];
	var timer = 0;

	function createShape(i)
	{
		if(elements[i] == null)
		{
			elements[i] = [];
			elements[i]['size'] = 10+Math.round(randomize(1, 3))*5;
			elements[i]['rotate'] = randomize(0, 360);
			elements[i]['shape'] = Math.round(randomize(0, 2));
			elements[i]['x'] = randomize(0, this.canvas.width);
			elements[i]['y'] = randomize(0, this.canvas.height);
			elements[i]['movementX'] = randomize(25, 50);
			elements[i]['movementOffsetX'] = randomize(0, 360);
			elements[i]['timerOffsetX'] = randomize(500, 1000);
			elements[i]['movementY'] = randomize(100, 200);
			elements[i]['movementOffsetY'] = randomize(0, 360);
			elements[i]['timerOffsetY'] = randomize(500, 1000);
		}
		drawRotatedRect(
				elements[i]['x']+Math.sin(timer/elements[i]['timerOffsetX']+elements[i]['movementOffsetX'])*elements[i]['movementX'],
				elements[i]['y']+Math.sin(timer/elements[i]['timerOffsetY']+elements[i]['movementOffsetY'])*elements[i]['movementY'],
				elements[i]['size'],
				elements[i]['rotate'],
				elements[i]['shape']
		);

	}

	setInterval(function(){

		this.ctx.clearRect(0, 0, this.canvas.width, this.canvas.height);
		this.ctx.beginPath();

		for (var i = 0; i < this.amount; i++)
		{
			createShape(i);
		}

		timer++;

	}, 16.66);

}