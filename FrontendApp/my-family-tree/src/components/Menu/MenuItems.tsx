import * as React from 'react';
import {FC} from 'react';
import {privateRoutes} from "../../router/routes";
import MenuItem from "./MenuItem";
import LogoutComponent from "./LogoutComponent";

interface MenuItemsProps {
    open: boolean
}

const MenuItems: FC<MenuItemsProps> = (props) => {
    const menuItems = privateRoutes.map((item) => (
        <MenuItem icon={item.icon} isOpen={props.open} title={item.title} path={item.path}/>
    ));

    menuItems.push(<LogoutComponent isOpen={props.open}/>)

    return (
        <>
            {menuItems}
        </>
    );
};

export default MenuItems;