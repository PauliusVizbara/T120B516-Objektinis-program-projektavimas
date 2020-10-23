"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/testHub").build();
connection.start()



const pathCells = [
    { x: 0, y: 1 }, { x: 1, y: 1 },
    { x: 2, y: 1 }, { x: 3, y: 1 },
    { x: 4, y: 1 }, { x: 5, y: 1 },
    { x: 6, y: 1 }, { x: 7, y: 1 },
    { x: 7, y: 2 }, { x: 7, y: 3 },
    { x: 7, y: 4 }, { x: 8, y: 4 },
    { x: 9, y: 4 }, { x: 10, y: 4 },
    { x: 11, y: 4 }, { x: 12, y: 4 },
    { x: 13, y: 4 }, { x: 14, y: 4 },
]



document.getElementById('start-game-button').addEventListener("click", (e) => {
    gameHubConnection.invoke("StartGame")
})

connection.on("ReceiveMessage", (x, y, unitType) => {
    document.getElementById(`${x}-${y}`).classList.toggle(unitType)
    document.getElementById(`${x}-${y}`).classList.toggle('occupied')
})


const unitSelectors = Array.from(document.getElementById("unit-selector").children)
unitSelectors.forEach(selector => {

    selector.addEventListener("click", (e) => {
        unitSelectors.forEach(selector => selector.classList.remove('active'))
        selector.classList.add('active')
        e.preventDefault()
    })

})



const gridSize = 15
const grid = Array(gridSize).fill().map(() => Array(gridSize).fill())
const gridDOM = document.getElementById("game-grid")
for (let i = 0; i < gridSize; i++) {
    for (let j = 0; j < gridSize; j++) {
        const cell = document.createElement('button')
        let isPathCell = false
        pathCells.forEach(({ x, y }) => {
            if (i === y && j === x) {
                cell.classList.add('path')
                isPathCell = true
            }
        })
        cell.id = `${i}-${j}`
        !isPathCell && cell.addEventListener("click", (e) => {
            const type = unitSelectors.find(el => el.classList.contains('active')).id
            console.log(type)
            const coordinates = cell.id.split('-')
            connection.invoke("SendMessage", coordinates[0], coordinates[1], type)
            e.preventDefault()
        })
        gridDOM.append(cell)
        grid[i][j] = cell

    }

}

const gameHubConnection = new signalR.HubConnectionBuilder().withUrl("/gameFlow").build();
gameHubConnection.start()

gameHubConnection.on('GameStatus', (data) => {
    const monsterList = data.monsterList
    Array.from(gridDOM.children).forEach(element => { element.classList.remove('monster1'); element.classList.remove('monster2'); element.classList.remove('monster3') })
    for (let i = 0; i < monsterList.length; i++) {
        const monster = monsterList[i]
        const { xCoordinate, yCoordinate, monsterType } = monster
        if (grid[yCoordinate - 1] && grid[yCoordinate - 1][xCoordinate - 1]) {
            grid[yCoordinate - 1][xCoordinate - 1].classList.add(`monster${monsterType}`)
        }
    }
})