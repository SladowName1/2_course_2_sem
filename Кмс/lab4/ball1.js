(function (lib, img, cjs, ss, an) {

var p; // shortcut to reference prototypes
lib.ssMetadata = [];


// symbols:
// helper functions:

function mc_symbol_clone() {
	var clone = this._cloneProps(new this.constructor(this.mode, this.startPosition, this.loop));
	clone.gotoAndStop(this.currentFrame);
	clone.paused = this.paused;
	clone.framerate = this.framerate;
	return clone;
}

function getMCSymbolPrototype(symbol, nominalBounds, frameBounds) {
	var prototype = cjs.extend(symbol, cjs.MovieClip);
	prototype.clone = mc_symbol_clone;
	prototype.nominalBounds = nominalBounds;
	prototype.frameBounds = frameBounds;
	return prototype;
	}


(lib.Символ1 = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// Слой 1
	this.shape = new cjs.Shape();
	this.shape.graphics.f("#330000").s().p("AhWBXQglgkABgzQgBgyAlgkQAkglAyABQAzgBAkAlQAkAkAAAyQAAAzgkAkQgkAkgzAAQgyAAgkgkg");

	this.timeline.addTween(cjs.Tween.get(this.shape).wait(1));

}).prototype = getMCSymbolPrototype(lib.Символ1, new cjs.Rectangle(-12.3,-12.3,24.7,24.7), null);


// stage content:
(lib.ball1 = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// timeline functions:
	this.frame_0 = function() {
		/* ball.addEventListener(Event.ENTER_FRAME, anim);
		var c: int = 1;
		function anim(event: Event) {
		if (c <= 21) {
		if (ball.x < 525)
		ball.x += 25;
		if (ball.y < 275)
		ball.y += 13;
		c++;
		}
		if (c > 21 && c <= 40) {
		if (ball.x > 245)
		ball.x -= 16;
		if (ball.y < 375)
		ball.y += 5;
		c++;
		}
		if (c > 40 && c <= 60) {
		if (ball.x > 30)
		ball.x -= 11;
		if (ball.y > 35)
		ball.y -= 18;
		c++;
		}
		}*/
		this.ball.addEventListener("enter_frame",anim.bind(this))
		var c: int = 1;
		function anim(event: Event) {
		if (c <= 21) {
		if (this.ball.x < 525)
		this.ball.x += 25;
		if (this.ball.y < 275)
		this.ball.y += 13;
		c++;
		}
		if (c > 21 && c <= 40) {
		if (this.ball.x > 245)
		this.ball.x -= 16;
		if (this.ball.y < 375)
		this.ball.y += 5;
		c++;
		}
		if (c > 40 && c <= 60) {
		if (this.ball.x > 30)
		this.ball.x -= 11;
		if (this.ball.y > 35)
		this.ball.y -= 18;
		c++;
		}
		}
	}

	// actions tween:
	this.timeline.addTween(cjs.Tween.get(this).call(this.frame_0).wait(1));

	// Слой 1
	this.ball = new lib.Символ1();
	this.ball.parent = this;
	this.ball.setTransform(33.4,44);

	this.timeline.addTween(cjs.Tween.get(this.ball).wait(1));

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(296,231.7,24.7,24.7);
// library properties:
lib.properties = {
	width: 550,
	height: 400,
	fps: 24,
	color: "#FFFFFF",
	opacity: 1.00,
	manifest: [],
	preloads: []
};




})(lib = lib||{}, images = images||{}, createjs = createjs||{}, ss = ss||{}, AdobeAn = AdobeAn||{});
var lib, images, createjs, ss, AdobeAn;