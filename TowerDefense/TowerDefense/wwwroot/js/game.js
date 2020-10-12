"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/testHub").build();
connection.start()

const gameHubConnection = new signalR.HubConnectionBuilder().withUrl("/gameFlow").build();
gameHubConnection.start()

const pathCells = [
    { x: 0, y: 1 }, { x: 1, y: 1 },
    { x: 2, y: 1 }, { x: 2, y: 2 },
    { x: 2, y: 3 }, { x: 2, y: 4 },
    { x: 2, y: 3 }, { x: 2, y: 4 },
    { x: 3, y: 4 }, { x: 4, y: 4 },
    { x: 5, y: 4 }, { x: 6, y: 4 },
    { x: 6, y: 5 }, { x: 6, y: 6 },
    { x: 6, y: 7 }, { x: 6, y: 8 },
    { x: 7, y: 8 }, { x: 8, y: 8 },
    { x: 9, y: 8 }, { x: 10, y: 8 },
    { x: 10, y: 9 }, { x: 10, y: 10 },
    { x: 10, y: 11 }, { x: 9, y: 11 },
    { x: 8, y: 11 }, { x: 7, y: 11 },
    { x: 7, y: 12 }, { x: 7, y: 13 },
    { x: 7, y: 14 },
]



document.getElementById('start-game-button').addEventListener("click", (e) => {
    gameHubConnection.invoke("StartGame")
})

connection.on("ReceiveMessage", (x, y, unitType) => {
    document.getElementById(`${x}-${y}`).classList.toggle(unitType)
    document.getElementById(`${x}-${y}`).classList.toggle('occupied')
})


const unitSelectors = Array.from(document.getElementById("unit-selector").children)
console.log(unitSelectors)
unitSelectors.forEach(selector => {

    selector.addEventListener("click", (e) => {
        unitSelectors.forEach(selector => selector.classList.remove('active'))
        selector.classList.add('active')
        e.preventDefault()
    })

})



const gridSize = 15
const grid = document.getElementById("game-grid")
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
        grid.append(cell)
    }

}
