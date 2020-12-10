"use strict";

const connection = new signalR.HubConnectionBuilder().withUrl("/gameFlow").configureLogging(signalR.LogLevel.Trace).build();
connection.start()


document.getElementById('start-game-button').addEventListener("click", (e) => {
    connection.invoke("StartGame")
})


connection.on('GameStatus', (data, towersList) => {
    console.log('Game state', data, towersList)
    document.getElementById('start-game-button').classList.add('hide')
    const monsterList = data.monsterList
    const deadMonstersList = data.deadMonstersList

    towersList.forEach(tower => {
        towers[tower.id] = {
            ...towers[tower.id],
            ...tower,
        }
    })

    deadMonstersList.forEach(monster => {
        const { monsterIndex: id } = monster 
        if (monsters[id]){
            monsters[id].remove()
            delete monsters[id]
         }
    })

    monsterList.forEach(monster => {
        const { monsterIndex: id, xCoordinate, currentHealth, yCoordinate, monsterType } = monster
        if (tiles[yCoordinate - 1] && tiles[yCoordinate - 1][xCoordinate - 1]) {
            if (!monsters[id]) {
                monsters[id] = new Entity({
                    currentHealth,
                    tile: tiles[xCoordinate - 1][yCoordinate - 1], sprite: sprites[`monster${monsterType}`],
                    onClick: () => uiManager.showMonsterMenu(monster),
                    renderBuilder: MonsterRenderBuilder,
                })
                monsters[id].render()
            }
            else {
                monsters[id].setHealth(currentHealth)
                monsters[id].move(tiles[xCoordinate - 1][yCoordinate - 1])
            }
        }
    })
})


const requestTowerBuild = (x, y, towerType) => {
    connection.invoke("RequestBuildTower", x, y, towerType)
}

const requestTowerUpgrade = (towerId, upgradeType) => {
    uiManager.hideMenus()
    connection.invoke("RequestUpgradeTower", towerId, upgradeType)
}


connection.on('BuildTower', (x, y, data, id) => {
    towers[id] = { x, y, ...data, id }
    const tower = new Entity({
        tile: tiles[x][y], sprite: sprites[data.name],
        onClick: () => uiManager.showTowerInfoMenu({ x, y, ...data, id }),
        renderBuilder: TowerRenderBuilder,
    })
    tower.render()
})
