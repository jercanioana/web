let board = document.getElementById("board");
let Xcoord, Ycoord = 0
let context = board.getContext("2d");
let snake = [{x: 150, y: 150},
    {x: 140, y: 150},
    {x: 130, y: 150},
    {x: 120, y: 150},
    {x: 110, y: 150},]

let LEFT = 37;
let UP = 38;
let RIGHT = 39;
let DOWN = 40;
let newX = 10;
let newY = 0;
let Obstacle1X = 0;
let Obstacle1Y = 0;
let Obstacle2X = 0;
let Obstacle2Y = 0;
let Obstacle3X = 0;
let Obstacle3Y = 0;
let startingTime = new Date();

function drawSnake(){
   snake.forEach( function(snakePart){
        context.fillStyle = 'blue';
        context.fillRect(snakePart.x, snakePart.y, 10, 10);
        context.strokeRect(snakePart.x, snakePart.y, 10, 10);
    })
}

function moveSnake(){
    const head = {x: snake[0].x + newX, y: snake[0].y + newY};
    snake.unshift(head);
    if(snake[0].x === Xcoord && snake[0].y === Ycoord){
        generateFood();

    }else{
        snake.pop();
    }

}
function drawBoard(){
    context.fillStyle = "white";
    context.strokeStyle = "black";
    context.fillRect(0, 0, board.width, board.height);
    context.strokeRect(0, 0, board.width, board.height);
}

function changeDirection(event){
    const keyPressed = event.keyCode;
    const goingUp = newY === -10;
    const goingDown = newY === 10;
    const goingRight = newX === 10;
    const goingLeft = newX === -10;
    if(keyPressed === LEFT && !goingRight){
        addMove(0,userid, "LEFT");
        newX = -10; newY = 0;
    }if(keyPressed === UP && !goingDown){

        addMove(0,userid, "UP");
        newX = 0; newY = -10;
    }if(keyPressed === RIGHT && !goingLeft){

        addMove(0,userid, "RIGHT");
        newX = 10; newY = 0;
    }if(keyPressed === DOWN && !goingUp){

        addMove(0,userid,"DOWN");
        newX = 0; newY = 10;
    }

}
function randomPosition(lowerBound, upperBound){
    return Math.round((Math.random() * (upperBound-lowerBound) + lowerBound) / 10) * 10;
}

function generateObstacle1(){
    Obstacle1X = randomPosition(0, board.width-10);
    Obstacle1Y = randomPosition(0, board.height-10);
    snake.forEach(function isObstacleOnSnake(part)
    {if(part.x === Obstacle1X && part.y === Obstacle1Y)
        generateObstacle1();
    });
}
function generateObstacle2(){
    Obstacle2X = randomPosition(0, board.width-10);
    Obstacle2Y = randomPosition(0, board.height-10);
    snake.forEach(function isObstacleOnSnake(part)
    {if(part.x === Obstacle2X && part.y === Obstacle2Y)
        generateObstacle2();
    });
}
function generateObstacle3(){
    Obstacle3X = randomPosition(0, board.width-10);
    Obstacle3Y = randomPosition(0, board.height-10);
    snake.forEach(function isObstacleOnSnake(part)
    {if(part.x === Obstacle3X && part.y === Obstacle3Y)
        generateObstacle3();
    });
}
function generateFood(){

    Xcoord = randomPosition(0, board.width-10);
    Ycoord = randomPosition(0, board.height-10);

    snake.forEach(function isFoodOnSnake(part)
    {if(part.x === Xcoord && part.y === Ycoord)
        generateFood();
    });
}
function drawFood() {

    context.fillStyle = 'red';
    context.strokestyle = 'darkred';
    context.fillRect(Xcoord, Ycoord, 10, 10);
    context.strokeRect(Xcoord, Ycoord, 10, 10);
}
function drawObstacle() {

    context.fillStyle = 'black';
    context.strokestyle = 'darkred';
    context.fillRect(Obstacle1X, Obstacle1Y, 10, 10);
    context.strokeRect(Obstacle1X, Obstacle1Y, 10, 10);
    context.fillRect(Obstacle2X, Obstacle2Y, 10, 10);
    context.strokeRect(Obstacle2X, Obstacle2Y, 10, 10);
    context.fillRect(Obstacle3X, Obstacle3Y, 10, 10);
    context.strokeRect(Obstacle3X, Obstacle3Y, 10, 10);
}
function endGame(){
    for(let i=4; i<snake.length; i++){

        if(snake[i].x === snake[0].x && snake[i].y === snake[0].y){

            //snake collided with itself
            return true;
        }else if(snake[0].x < 0 || snake[0].x > board.width - 10 || snake[0].y < 0 || snake[0].y > board.height - 10){

            //snake hit the wall
            return true;
        }else if(snake[0].x === Obstacle1X && snake[0].y === Obstacle1Y || snake[0].x === Obstacle2X && snake[0].y === Obstacle2Y || snake[0].x === Obstacle3X && snake[0].y === Obstacle3Y ){

            //snake hit the obstacle
            return true;
        }
    }
    return false;
}
function keepTrackOfTime(){
    startingTime = new Date() - startingTime;
    let secondsSpent = Math.round(startingTime/1000);
    let minutesSpent = Math.round(secondsSpent/60);
    let hoursSpent = Math.round(minutesSpent/60);
    if(secondsSpent < 10)
        secondsSpent = "0" + secondsSpent;
    if(minutesSpent < 10)
        minutesSpent = "0" + minutesSpent;
    if(hoursSpent < 10)
        hoursSpent = "0" + hoursSpent;
    let timeSpent = hoursSpent + ":" + minutesSpent + ":" + secondsSpent;
    updateTime(userid, timeSpent);
}
function main(){

    setTimeout(function onTick(){
        if (endGame()) {
            keepTrackOfTime();
            return;
        }
        drawBoard();
        drawFood();
        drawObstacle();
        moveSnake();
        drawSnake();
        main();
        document.addEventListener("keydown", changeDirection);
    }, 100);
}