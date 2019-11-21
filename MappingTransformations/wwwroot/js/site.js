
var c = document.getElementById("canvas");
var ctx = c.getContext("2d");

ctx.beginPath();
for (let i = 10; i <= 610; i+=30)
{
ctx.lineWidth = 1;
ctx.strokeStyle = "lightgray";
ctx.moveTo(i,10);
ctx.lineTo(i,610);
ctx.stroke();

ctx.moveTo(10,i);
ctx.lineTo(610,i);
ctx.stroke();
}
ctx.closePath();

ctx.beginPath();
ctx.lineWidth = 2;
ctx.strokeStyle = "black";

ctx.moveTo(310,0);
ctx.lineTo(310,620);
ctx.stroke();

ctx.moveTo(0,310);
ctx.lineTo(620,310);
ctx.stroke();

ctx.moveTo(0,310);
ctx.lineTo(5,315);
ctx.stroke();

ctx.moveTo(0,310);
ctx.lineTo(5,305);
ctx.stroke();

ctx.moveTo(620,310);
ctx.lineTo(615,305);
ctx.stroke();

ctx.moveTo(620,310);
ctx.lineTo(615,315);
ctx.stroke();

ctx.moveTo(310,0);
ctx.lineTo(305,5);
ctx.stroke();
ctx.moveTo(310,0);
ctx.lineTo(315,5);
ctx.stroke();
ctx.moveTo(310,620);
ctx.lineTo(315,615);
ctx.stroke();
ctx.moveTo(310,620);
ctx.lineTo(305,615);
ctx.stroke();
ctx.closePath();

ctx.beginPath();
ctx.font = "15px Arial";
ctx.fillStyle = "red";

ctx.fillText("y",320, 10);
ctx.fillText("x",612, 325);
ctx.closePath();

ctx.beginPath();
ctx.font = "18px Arial";
ctx.fillStyle = "blue";

for (let i = 2; i <= 8; i+=2) {
        ctx.fillText(i,294, -30*i+316);
        ctx.fillText(-i,290, 30*i+316)
        ctx.fillText(-i,-30*i+299, 328);
        ctx.fillText(i,30*i+306, 328);  
    }
ctx.closePath();