const canvas: HTMLCanvasElement = document.getElementById("canvas") as HTMLCanvasElement;
const ctx = canvas.getContext("2d") as CanvasRenderingContext2D;

canvas.height = 800;
canvas.width = 600;

const greetUser = () => {
    console.log("Hello, world!");
}

greetUser();

class Track {
    x: number;
    y: number;
    w: number;
    h: number;
    left: number[];
    right: number[];

    constructor() {
        this.x = 0;
        this.y = 0;
        this.w = canvas.width;
        this.h = this.w / 4;
        this.left = [1, 0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0];
        this.right = [1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1];
    }

    draw = () => {

        // Draw left hand
        ctx.fillStyle = "#ff0000";
        this.left.forEach((a, b) => {
            let xOffset = this.x + b * (this.w / 16);
            // ctx.ellipse(xOffset, this.y, this.w / 8, 0, 0, 0, 0);
            if (a) ctx.fillRect(xOffset, this.y, this.w / 17, this.h / 2);
        })

        //Draw right hand
        ctx.fillStyle = "#0000ff";
        this.right.forEach((a, b) => {
            let xOffset = this.x + b * (this.w / 16);
            // ctx.ellipse(xOffset, this.y, this.w / 8, 0, 0, 0, 0);
            if (a) ctx.fillRect(xOffset, this.y + this.h/2, this.w / 17, this.h / 2);
        })
    }
}

class Cursor {
    bpm: number;
    pos: number;

    constructor() {
        this.bpm = 120;
        this.pos = 0;
    }

    update = (deltaTime: number) {

    }

    draw = () => {
        ctx
    }
}

const track = new Track();
track.draw();

let time = Date.now();
let animationFrameID = 0;
const update = (delta: number) => {
    
}

const render = () => {
    // Clear canvas
    ctx.fillStyle = "#ffffff";
    ctx.fillRect(0, 0, canvas.width, canvas.height);
    track.draw();
}

const gameLoop = (current: number) => {
    const delta = current - time;
    time = current;
    update(delta);
    render();
    animationFrameID = requestAnimationFrame(gameLoop);
}

gameLoop(Date.now());
