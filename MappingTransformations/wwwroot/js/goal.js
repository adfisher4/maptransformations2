var c = document.getElementById("canvas");
var ctx = c.getContext("2d");

function drawGoal(goalPoints) {
    document.getElementById("NextLevel").style.display = "none";
    ctx.beginPath();
    ctx.lineWidth = 2.5;
    ctx.strokeStyle = "blue";
    //draw 
    ctx.moveTo(goalPoints[0], goalPoints[1]);
    ctx.lineTo(goalPoints[2], goalPoints[3]);
    ctx.stroke();
    ctx.moveTo(goalPoints[4], goalPoints[5]);
    ctx.lineTo(goalPoints[2], goalPoints[3]);
    ctx.stroke();
    ctx.moveTo(goalPoints[4], goalPoints[5]);
    ctx.lineTo(goalPoints[6], goalPoints[7]);
    ctx.stroke();
    ctx.moveTo(goalPoints[6], goalPoints[7]);
    ctx.lineTo(goalPoints[0], goalPoints[1]);
    ctx.stroke();
    ctx.closePath();
}

function drawFig(StartPoints) {
    var display = "none";
    ctx.beginPath();
    ctx.lineWidth = 2.5;
    ctx.strokeStyle = "#f48806";
    //draw 
    ctx.moveTo(StartPoints[0], StartPoints[1]);
    ctx.lineTo(StartPoints[2], StartPoints[3]);
    ctx.stroke();
    ctx.moveTo(StartPoints[4], StartPoints[5]);
    ctx.lineTo(StartPoints[2], StartPoints[3]);
    ctx.stroke();
    ctx.moveTo(StartPoints[4], StartPoints[5]);
    ctx.lineTo(StartPoints[6], StartPoints[7]);
    ctx.stroke();
    ctx.moveTo(StartPoints[0], StartPoints[1]);
    ctx.lineTo(StartPoints[6], StartPoints[7]);
    ctx.stroke();
    ctx.closePath();

    if (StartPoints[0] == goalPoints[0] && StartPoints[1] == goalPoints[1] && StartPoints[2] == goalPoints[2] && StartPoints[3] == goalPoints[3] && StartPoints[4] == goalPoints[4] && StartPoints[5] == goalPoints[5] && StartPoints[6] == goalPoints[6] && StartPoints[7] == goalPoints[7]) {
        if (goalPoints[0] == 520) {
            ctx.font = "24px Comic Sans MS";
            ctx.fillStyle = "red";
            ctx.textAlign = "center";
            ctx.fillText("Congratulations!!! You've finished all the levels!", canvas.width / 2, canvas.height / 3.4)
            ctx.font = "20px Comic Sans MS";
            ctx.fillStyle = "red";
            ctx.textAlign = "center";
            ctx.fillText("The lowest(best) possible score you can get is 18.", canvas.width / 2, canvas.height / 2.7)
            ctx.fillText("If you didn't get an 18:", canvas.width / 2, canvas.height / 2.4);
            ctx.fillText("Hit the Reset button and try to get a better score.", canvas.width / 2, canvas.height / 2.1);
        }

        else {
            ctx.font = "50px Comic Sans MS";
            ctx.fillStyle = "red";
            ctx.textAlign = "center";
            ctx.fillText("Level Complete!!", canvas.width / 2, canvas.height / 2.5);

            document.getElementById("NextLevel").style.display = "block";
        }
    }
}

// function isItOff(result) {
//     if (result == false) {
//         continue;
//     }
//     else {
//         alert("That translation...")
//     }
// }

// isItOff(offGrid);
drawGoal(goalPoints);
drawFig(points);