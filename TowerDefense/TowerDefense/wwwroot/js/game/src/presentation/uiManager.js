class UIManager {
    constructor(element) {
        this.container = element
        this.init()
       
    }


    showTowerBuildingMenu(data) {
        this.hideMenus()
        const menu = this.menus['tower-building-menu']
        menu.classList.add('show')
        menu.getElementsByClassName('tower-building-menu-x')[0].innerText = data.x
        menu.getElementsByClassName('tower-building-menu-y')[0].innerText = data.y
        Object.entries(data).forEach(([key, value]) => menu.setAttribute(`data-${key}`, value))
    }

    showMonsterMenu(data) {
        this.hideMenus()
        const menu = this.menus['monster-info']
        menu.classList.add('show')
        Object.entries(data).forEach(([key, value]) => menu.setAttribute(`data-${key}`, value))

    }

    showTowerInfoMenu(data) {
        this.hideMenus()
        const menu = this.menus['tower-info-menu']
        menu.classList.add('show')
        Object.entries(data).forEach(([key, value]) => menu.setAttribute(`data-${key}`, value))

    }

    init() {
        this.menus = {}
        this.menuRenders = {}
        this.menus['tower-building-menu'] = this.container.getElementsByClassName('tower-building-menu')[0]
        this.menus['monster-info'] = this.container.getElementsByClassName('monster-info')[0]
        this.menus['tower-info-menu'] = this.container.getElementsByClassName('tower-info-menu')[0]
        this.hideMenus()
    }


    hideMenus(){
        Array.from(Object.values(this.menus)).forEach(menu => menu.classList.remove('show'))
    }
}
