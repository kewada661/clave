"use strict";
const canvas = document.getElementById("canvas");
const ctx = canvas.getContext("2d");
canvas.height = 800;
canvas.width = 600;
const greetUser = () => {
    console.log("Hello, world!");
};
greetUser();
class Track {
    constructor() {
        this.draw = () => {
            // Clear canvas
            ctx.fillStyle = "#ffffff";
            ctx.fillRect(0, 0, canvas.width, canvas.height);
            // Draw left hand
            ctx.fillStyle = "#ff0000";
            this.left.forEach((a, b) => {
                let xOffset = this.x + b * (this.w / 16);
                // ctx.ellipse(xOffset, this.y, this.w / 8, 0, 0, 0, 0);
                if (a)
                    ctx.fillRect(xOffset, this.y, this.w / 17, this.h / 2);
            });
            //Draw right hand
            ctx.fillStyle = "#0000ff";
            this.right.forEach((a, b) => {
                let xOffset = this.x + b * (this.w / 16);
                // ctx.ellipse(xOffset, this.y, this.w / 8, 0, 0, 0, 0);
                if (a)
                    ctx.fillRect(xOffset, this.y + this.h / 2, this.w / 17, this.h / 2);
            });
        };
        this.x = 0;
        this.y = 0;
        this.w = canvas.width;
        this.h = this.w / 4;
        this.left = [1, 0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0];
        this.right = [1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1];
    }
}
const track = new Track();
track.draw();
//# sourceMappingURL=main.js.map