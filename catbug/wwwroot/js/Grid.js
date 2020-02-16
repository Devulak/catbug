function Grid(container, minWidth)
{
	// Varibles + construct
	this.container = container;
	this.minWidth = minWidth;
	this.ratioX = 1;
	this.ratioY = 1;

	// Function update
	this.update = function(event)
	{
		// Define the size of the grid (min. 1)
		var length = Math.floor(this.container.offsetWidth/this.minWidth);
		length = length ? length : 1;

		// Define the scaling
		var scale = this.container.offsetWidth/length

		// Create array (x)
		var grid = [];

		// Make array 2D with defined grid size (y)
		for(var i = 0; i < length; i++)
		{
			grid[i] = [];
		}

		// Define the children
		var children = this.container.children;

		// Loop children, y, x
		// In order what's being looped first: x, y, children (reversed of appearence)
		// i = children
		// j = y
		// k = x
		for(var i = 0; i < children.length; i++)
		{
			// Put a breaker
			var hasPlaced = false;
			// convert to true when tested
			for(var j = 0; !hasPlaced; j++)
			{
				for(var k = 0; k < grid.length; k++)
				{
					// Check to see if there's enough available space; x, y
					// In order: y, x
					// l = y
					// m = x
					var available = true;

					// Create size and limit it on certain sizes
					var size = children[i].getAttribute("size");
					size = size > 1 ? size : 1;
					if(size > 3)
					{
						size = 3;
					}
					if(size > 2 && length <= 5)
					{
						size = 2;
					}
					if(size > 1 && length <= 3)
					{
						size = 1;
					}

					for(var l = 0; l < size && available; l++)
					{
						for(var m = 0; m < size && available; m++)
						{
							if(length <= k+m || grid[k+m][j+l])
							{
								available = false;
							}
						}
					}

					// Is there enough space?
					if(available)
					{
						// Space found, finish task for child

						// Reserve Space
						for(var l = 0; l < size; l++)
						{
							for(var m = 0; m < size; m++)
							{
								grid[k+m][j+l] = true;
							}
						}

						// Tell previous loop to stop
						hasPlaced = true;

						// Set height fix to match ratio
						var ratioFix = this.ratioY/this.ratioX;

						// Prettify and place child
						children[i].style.left = scale*k + "px";
						children[i].style.top = scale*j*ratioFix + "px";
						children[i].style.width = scale*size + "px";
						children[i].style.height = scale*size*ratioFix + "px";

						// Break out of current loop
						break;
					}
				}
			}
		}
	}

	// Function ratio
	this.setRatio = function(x, y)
	{
		this.ratioX = x;
		this.ratioY = y;
		this.update();
	}

	// Constructor
	this.update();
	this.update();
	window.addEventListener('resize', this.update.bind(this));
}