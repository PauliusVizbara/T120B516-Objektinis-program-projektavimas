PIXI.utils.skipHello();

var app = new PIXI.Application({
    backgroundColor: 0x11151C,
    antialias: true,
    autoDensity: true,
    resolution: 2
})

const viewport = new Viewport.Viewport({
    screenWidth: window.innerWidth,
    screenHeight: window.innerHeight,
    worldWidth: 1000,
    worldHeight: 1000,
    interaction: app.renderer.plugins.interaction // the interaction module is important for wheel to work properly when renderer.view is placed or scaled
})

app.stage.addChild(viewport)
viewport.drag().wheel()
document.body.appendChild(app.view)

app.renderer.resize(window.innerWidth, window.innerHeight)
window.addEventListener("resize", function () {
    app.renderer.resize(window.innerWidth, window.innerHeight)
})

const stage = app.stage
const mapSize = 15
const cellSize = 40
const cellHeight = 4
let startingX = 600
let startingY = 40
const tiles = Array(mapSize).fill().map(() => Array(mapSize).fill())
const monsters = {}
const towers = {}
const pathTiles = [
    {x: 0, y: 1}, {x: 1, y: 1},
    {x: 2, y: 1}, {x: 3, y: 1},
    {x: 4, y: 1}, {x: 5, y: 1},
    {x: 6, y: 1}, {x: 7, y: 1},
    {x: 7, y: 2}, {x: 7, y: 3},
    {x: 7, y: 4}, {x: 8, y: 4},
    {x: 9, y: 4}, {x: 10, y: 4},
    {x: 11, y: 4}, {x: 12, y: 4},
    {x: 13, y: 4}, {x: 14, y: 4},
]


for (let cellX = 0; cellX < mapSize; cellX++) {
    for (let cellY = 0; cellY < mapSize; cellY++) {
        const X = startingX - cellY * cellSize
        const Y = startingY + ((cellSize + cellHeight) / 2) * cellY
        const tileType = !!pathTiles.find(({x, y}) => cellY === y && cellX === x) ? 'path' : 'ground'
        tiles[cellX][cellY] = new Tile({x: cellX, y: cellY, stage: stage, tileRenderPoint: {x: X, y: Y}, type: tileType})
    }
    startingX += cellSize
    startingY += ((cellSize + cellHeight) / 2)
}

for (let i = 0; i < tiles.length; i++) {
    for (let j = 0; j < tiles[i].length; j++) {
        tiles[i][j].render()
    }
}

const uiManager = new UIManager(document.getElementById('ui-container'))

const sprites = {
    monster1: {
        spritePath: '/images/monsterTile1.png',
        scale: [0.3,0.3],
    },
    Archer: {
        spritePath: '/images/archer-tower.png',
        scale: [0.2, 0.2],
        pivot: [0.5, 0.9],
    },
    Freeze: {
        spritePath: '/images/archer-tower.png',
        scale: [0.2, 0.2],
        pivot: [0.5, 0.9],
    },
    Bomber: {
        spritePath: '/images/bomb-tower.png',
        scale: [0.2, 0.2],
        pivot: [0.5, 0.9],
    },
    Bank: {
        spritePath: '/images/archer-tower.png',
        scale: [0.2, 0.2],
        pivot: [0.5, 0.9],
    },
    Mage: {
        spritePath: '/images/mage-tower.png',
        scale: [0.2, 0.2],
        pivot: [0.5, 0.9],
    }
}

//new Entity({ tile: tiles[1][1], sprite: sprites.monster1 }).render()
//new Entity({ tile: tiles[3][1], sprite: sprites.monster1 }).render()

//new Entity({ tile: tiles[6][6], sprite: sprites.archerTower, onClick: () => { uiManager.showTowerInfoMenu({})}}).render()