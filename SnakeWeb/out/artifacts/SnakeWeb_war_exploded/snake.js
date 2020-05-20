let board = document.getElementById("board");
let Xcoord, Ycoord = 0
let context = board.getContext("2d");
let snake = [{x: 150, y: 150},
    {x: 140, y: 150},
    {x: 130, y: 150},
    {x: 120, y: 150},
    {x: 110, y: 150},]
let ID = 0;
let LEFT = 37;
let UP = 38;
let RIGHT = 39;
let DOWN = 40;
let newX = 10;
let newY = 0;
let ObstacleX = 0;
let ObstacleY = 0;


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
        ID++;
        addMove(ID, "LEFT");
        newX = -10; newY = 0;
    }if(keyPressed === UP && !goingDown){
        ID++;
        addMove(ID, "UP");
        newX = 0; newY = -10;
    }if(keyPressed === RIGHT && !goingLeft){
        ID++;
        addMove(ID, "RIGHT");
        newX = 10; newY = 0;
    }if(keyPressed === DOWN && !goingUp){
        ID++;
        addMove(ID, "DOWN");
        newX = 0; newY = 10;
    }

}
function randomPosition(lowerBound, upperBound){
    return Math.round((Math.random() * (upperBound-lowerBound) + lowerBound) / 10) * 10;
}
function generateObstacle(){
    ObstacleX = randomPosition(0, board.width-10);
    ObstacleY = randomPosition(0, board.height-10);
    snake.forEach(function isObstacleOnSnake(part)
    {if(part.x === ObstacleX && part.y === ObstacleY)
        generateObstacle();
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
    context.fillRect(ObstacleX, ObstacleY, 10, 10);
    context.strokeRect(ObstacleX, ObstacleY, 10, 10);
}
function endGame(){
    for(let i=4; i<snake.length; i++){

        if(snake[i].x === snake[0].x && snake[i].y === snake[0].y){
            //snake collided with itself
            return true;
        }else if(snake[0].x < 0 || snake[0].x > board.width - 10 || snake[0].y < 0 || snake[0].y > board.height - 10){
            //snake hit the wall
            return true;
        }else if(snake[0].x === ObstacleX && snake[0].y === ObstacleY){
            console.log(snake[0].x);
            console.log(ObstacleX);

            //snake hit the obstacle
            return true;
        }
    }
    return false;
}
function main(){

    setTimeout(function onTick(){
        if (endGame()) return;
        drawBoard();
        drawFood();
        drawObstacle();
        moveSnake();
        drawSnake();
        main();
        document.addEventListener("keydown", changeDirection);
    }, 100);
}