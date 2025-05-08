let gridColor = document.getElementsByTagName("section");
let imgs = document.getElementsByTagName("img");

let takeAChanceText = ["Second Place in Beauty Contest: $10", "Bank Pays You Dividend of $50","Repair your Properties. You owe $250", "Speeding Fine: $15", "Holiday Fund Matures: Receive $100", "Pay Hospital Fees: $100"];
let takeAChanceMoney = [10, 50, -250, -15, 100, -100];

let rentArr=[];
let imageArr=[];

let timeS = 500;

let counterTurn = 0;
let currentXP1 = 11;
let currentYP1 = 11;
let currentXP2 = 11;
let currentYP2 = 11;
let trunP1 = 0;

let play1i;
let play2i;

let moneyP1 = 3000;
let moneyP2 = 3000;

//when the window load
window.onload= () =>
{  
    loadImg(); //load all the dice image
    FixingGrid();//fix the grid spots
    FixingColor();//fixing the colors of the grid
    FixingImg();//fixing player img
    Turn();//getting the player turn
    setValue();//set value in the ui price
    moneyUpdate();//money update for player
    
    document.querySelector("#RollDice").onclick = Random;//callng for random when click

} 
function loadImg()//preload image
{
    for(let i = 0; i < 6 ; i++)
    {
        imageArr[i] = `<img class="die" src="../images/LAB2_dice`+(i+1)+`.png">`;
    }
}
function test(player, step)//test fuction for the console
{
    movePlayer(player, step);
    if(player == 1)
    trunP1 = 1;
    else
    trunP1 = 0;
}  
function moneyUpdate()//money update in UI everytime it called
{
    document.querySelector("#player1amt").innerHTML = "$"+moneyP1;
    document.querySelector("#player2amt").innerHTML = "$"+moneyP2;
}

function FixingGrid()//loop to fix the grid by using the suite value
{
    for (let i = 0; i< gridColor.length; i++)
    {
        let suite = gridColor[i].getAttribute("suite");
        gridColor[i].style.gridRowStart = suite[0] + suite[1];
        gridColor[i].style.gridColumnStart = suite[2] + suite[3];

        if ((suite[0] + suite[1]) == "11" && (suite[2] + suite[3]) =="11")//inti
        {
            play1i = document.createElement('img');
            play1i.setAttribute('src', '../images/LAB1_Boy.png')
            gridColor[i].appendChild(play1i);
            play2i = document.createElement('img');
            play2i.setAttribute('src', '../images/LAB1_Girl.png')
            gridColor[i].appendChild(play2i);
        }
    }
}
function FixingColor()
{
    for (let i = 0; i< gridColor.length; i++)
    {
        if (gridColor[i].classList.contains("brown") || gridColor[i].classList.contains("lightblue"))
        {
            gridColor[i].classList.add(`top`);
        }
        if (gridColor[i].classList.contains("purple") || gridColor[i].classList.contains("orange"))
        {
            gridColor[i].classList.add(`right`);
        }
        if (gridColor[i].classList.contains("red") || gridColor[i].classList.contains("yellow"))
        {
            gridColor[i].classList.add(`bottom`);
        }
        if (gridColor[i].classList.contains("green") || gridColor[i].classList.contains("blue"))
        {
            gridColor[i].classList.add(`left`);
        }
    }
}
function FixingImg()
{
    let gridDiv = document.getElementById("player1");

    gridDiv.innerHTML = "<p>player 1</p>" + `<img src="../images/LAB1_Boy.png">`;
   
    gridDiv = document.getElementById("player2");

    gridDiv.innerHTML = "<p>player 2</p>" + `<img src="../images/LAB1_Girl.png">`;
    
    gridDiv = document.getElementById("die1");

    gridDiv.innerHTML = `<img class="die" src="../images/LAB2_dice1.png">`;

    gridDiv = document.getElementById("die2");

    gridDiv.innerHTML = `<img class="die" src="../images/LAB2_dice1.png">`;
}

function Random()
{
    document.getElementById("RollDice").disabled = true;

    let rng1 = Math.floor(Math.random() * (6 - 1 + 1)) + 1;

    let gridDiv = document.getElementById("die1");

    gridDiv.innerHTML = imageArr[rng1-1];

    let rng2 = Math.floor(Math.random() * (6 - 1 + 1)) + 1;

    gridDiv = document.getElementById("die2");

    gridDiv.innerHTML = imageArr[rng2-1];

    movePlayer(trunP1 , rng1 + rng2);

    counterTurn++;
    
    double(rng1, rng2);
    

}
function double(rng1 , rng2)
{
    if(rng1 == rng2)
    {
        counterTurn--;
    }
}

function Turn()
{

    if (counterTurn % 2)
    {
        imgs[2].classList.remove(`active`);
        imgs[3].classList.add(`active`);
        trunP1 = 0;
    }
    else 
    {
        imgs[3].classList.remove(`active`);
        imgs[2].classList.add(`active`);
        trunP1 = 1;
    }
    
}
function setValue()
{
    for (let i = 0; i < gridColor.length; ++i) 
    {
        let value = gridColor[i].getAttribute("val");

        if (value !== null && value > 0 && value != 50)
        {
            gridColor[i].innerHTML += '<p> $' + value + '</p>';
            rentArr[i] = value*0.10;
        }
    }
}
function secondTimeout( x, y)
{ 
    tax(x, y);
    jailAlert(x, y);
    jail(x, y);
    chances(x, y);

    if(trunP1 == 1)
    { 
       adding(currentXP1,currentYP1,play1i);
       x=currentXP1;
       y=currentYP1;
    }
    else
    {
        adding(currentXP2,currentYP2,play2i);
        x=currentXP2;
        y=currentYP2;
    }

    oWn(x, y);

    document.getElementById("RollDice").disabled = false;

    Turn();
}
function movePlayer(trunP1 ,steps) 
{ 
    endGame();

    if (trunP1 == 1)
    {
        for (let  i = 0; i < steps; i++)
        {

            if (currentYP1 > 1 &&  currentXP1 == 11)
            {
                currentYP1--;
            }
            else if(currentYP1 == 1 && currentXP1 > 1)
            {
                currentXP1--;
            }
            else if (currentXP1 == 1 && currentYP1 < 11)
            {
                currentYP1++;
            }
            else if(currentYP1 == 11 && currentXP1 < 11)
            {
                currentXP1++;
            }
            
            go(currentXP1, currentYP1);
            
            setTimeout(adding, timeS*i, currentXP1, currentYP1, play1i);
            
        }
        
        setTimeout(secondTimeout, timeS * steps, currentXP1, currentYP1);
        
    }
    else
    {
        for (let  i = 0; i < steps; i++)
        {

            if (currentYP2 > 1 && currentXP2 == 11)
            {
                currentYP2--;
            }
            else if(currentYP2 == 1 && currentXP2 > 1)
            {
                currentXP2--;
            }
            else if (currentXP2 == 1 && currentYP2 < 11)
            {
                currentYP2++;
            }
            else if(currentYP2 == 11 && currentXP2 < 11)
            {
                currentXP2++;
            }

            go(currentXP2, currentYP2);

           setTimeout( adding,timeS*i, currentXP2, currentYP2, play2i);
        }
        
        setTimeout(secondTimeout, timeS * steps, currentXP2, currentYP2);


    }

}

function adding(x, y, name)
{
    for (let i = 0; i< gridColor.length; i++)
    {
        let suite = gridColor[i].getAttribute("suite");

        if ((suite[0] + suite[1]) == ""+ formatting(x) && (suite[2] + suite[3]) == ""+ formatting(y))
        {
            gridColor[i].appendChild(name);
        }
    }
    
}
function formatting(number)
{   
    if (number >= 10)
        return number;
    
    else 
        return "0" + number; 
}
function go(x, y)
{
    if(x == 11 && y == 11)
    {
        if(trunP1 == 1)
        {
            moneyP1 += 200;
        }
        else
        {
            moneyP2 += 200;
        }
        moneyUpdate();
    }
}
function tax(x,y)
{
    if(x == 11 && y == 7)
    {
        let val = document.querySelector("#incometax").getAttribute("val");

        if(trunP1 == 1)
        {
            moneyP1 -= val;
        }
        else 
        {
            moneyP2 -= val;
        }
        window.alert("You have landed on income tax -$"+ val );
    }
    if (x == 9 && y == 11)
    {
        let val = document.querySelector("#luxurytax").getAttribute("val");

        if(trunP1 == 1)
        {
            moneyP1 -= val;
        }
        else 
        {
            moneyP2 -= val;
        }
        
        window.alert("You have landed on luxury tax -$"+ val );

    }

    moneyUpdate();

}
function jailAlert(x , y)
{
    if(x == 11 && y == 1)
        window.alert("thank you for visting jail");
}
function jail(x, y)
{
    if(x == 1 && y == 11)
    {
        if(trunP1 == 1)
        {
            currentXP1 = 11;
            currentYP1 = 1;
            moneyP1 -= 50;
        }
        else 
        {
            currentXP2 = 11;
            currentYP2 = 1;
            moneyP2 -= 50;
        }
        moneyUpdate();
    }
}
function idSearch(x, y)
{
    for (let i = 0; i< gridColor.length; i++)
    {
        let suite = gridColor[i].getAttribute("suite");

        if ((suite[0] + suite[1]) == ""+formatting(x) && (suite[2] + suite[3]) ==""+formatting(y))
        {
            return i;
        }
    }

}
function oWn(x , y)
{
    let i = idSearch(x, y);
    let check = document.querySelector("#"+gridColor[i].id);
    if (valid(formatting(x),formatting( y)))
    {
        if(trunP1 == 1)
        {
            if(check.classList.contains("own1") == false && check.classList.contains("own2") == false)
            {
                moneyP1 -= check.getAttribute("val");
                check.classList.add("own1");
                gridColor[i].style.setProperty('background-color', 'lightgreen') ;
            }
            else
            {
                if(check.classList.contains("own1") == true)
                {
                    moneyP1 = moneyP1;
                }
                else 
                {
                    moneyP1 -= rentArr[i];
                    moneyP2 += rentArr[i];
                    window.alert("Player one pays to player two $"+rentArr[i])
                    rentArr[i] = Math.ceil(rentArr[i]*1.20);
                    console.log("New rent: $"+rentArr[i]);
                }
            }
            
            moneyUpdate();
        }
        else
        {
            if(check.classList.contains("own2") == false && check.classList.contains("own1") == false)
            {
                moneyP2 -= check.getAttribute("val");
                check.classList.add("own2");
                gridColor[i].style.setProperty('background-color', 'violet') ;
            }
            else
            {
                if(check.classList.contains("own2") == true)
                {
                    moneyP2 = moneyP2;
                }
                else 
                {
                    moneyP2 -= rentArr[i];
                    moneyP1 += rentArr[i];
                    window.alert("Player two pays to player onw $"+rentArr[i])
                    rentArr[i] = Math.ceil(rentArr[i]*1.20);
                    console.log("New rent: $"+rentArr[i]);
                }
            }
            moneyUpdate();
        }
    }
}

function valid(x, y)
{
    if((x == ""+11 && y == "0"+1) || (x == "0"+1 && y == "0"+1) || (x == ""+11 && y == ""+11) ||(x == "0"+1 && y == ""+11) )
        return false;

    else if ((x == ""+11 && y == "0"+9) || (x == ""+11 && y == "0"+7) || (x == ""+11 && y == "0"+4) ||(x == "0"+4 && y == "0"+1) )
        return false;

    else if ((x == "0"+1 && y == "0"+3) || (x == "0"+4 && y == ""+11) || (x == "0"+7 && y == ""+11) ||(x == "0"+9 && y == ""+11) )
        return false;

    else 
        return true;
}
function chances(x, y)
{
    let rng =  Math.floor(Math.random() * 6 ) + 1;

    if((x == 11 && y == 4) || (x ==11 && y == 9) || (x == 4 && y == 1) || (x == 1 && y == 3) || (x == 4 && y == 11) || (x == 7 && y == 11))
    {
        window.alert(""+takeAChanceText[rng]);
        if(trunP1 == 1)
        {
            moneyP1 += takeAChanceMoney[rng];
        }
        else 
        {
            moneyP2 += takeAChanceMoney[rng];
        }
    }
    moneyUpdate();

}
function endGame()
{
    if(moneyP1 <= 0 || moneyP2 <= 0)
    {
        if(moneyP1 <= 0)
        {
            window.alert("Player 2 wins");
        }
        else
        {
            window.alert("Player 1 WINS");
        }

        location.reload();
    }
}


