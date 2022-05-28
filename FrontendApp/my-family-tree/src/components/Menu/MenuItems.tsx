import * as React from 'react';
import {FC} from 'react';
import ListItem from "@mui/material/ListItem";
import ListItemButton from "@mui/material/ListItemButton";
import ListItemIcon from "@mui/material/ListItemIcon";
import ListItemText from "@mui/material/ListItemText";
import {privateRoutes} from "../../router/routes";
import {SvgIcon} from "@mui/material";
import {Link} from "react-router-dom";

interface MenuItemsProps {
    open: boolean
}

const MenuItems: FC<MenuItemsProps> = (props) => {
    const menuItems = privateRoutes.map((item) => (
        <ListItem key={item.title} disablePadding sx={{display: 'block'}}>
            <ListItemButton component={Link} to={item.path}>
                <ListItemIcon
                    sx={{
                        minWidth: 0,
                        mr: props.open ? 3 : 'auto',
                        justifyContent: 'center',
                    }}
                >
                    <SvgIcon component={item.icon}/>
                </ListItemIcon>
                <ListItemText primary={item.title} sx={{opacity: props.open ? 1 : 0}}/>
            </ListItemButton>
        </ListItem>
    ));

    return (
        <>
            {menuItems}
        </>
    );
};

export default MenuItems;