import * as React from 'react';
import {FC} from 'react';
import {sideBarMenuRoutes} from "../../router/routes";
import MenuItem from "./MenuItem";
import LogoutComponent from "./LogoutComponent";

interface MenuItemsProps {
    open: boolean
}

const MenuItems: FC<MenuItemsProps> = (props) => {
    const menuItems = sideBarMenuRoutes.map((item) => (
        <MenuItem key={item.title} icon={item.icon} isOpen={props.open} title={item.title} path={item.path}/>
    ));

    menuItems.push(<LogoutComponent key="close" isOpen={props.open}/>)

    return (
        <>
            {menuItems}
        </>
    );
};

export default MenuItems;