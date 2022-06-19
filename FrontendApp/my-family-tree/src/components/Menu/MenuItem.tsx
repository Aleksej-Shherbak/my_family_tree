import React from 'react';
import ListItemButton from "@mui/material/ListItemButton";
import {Link} from "react-router-dom";
import ListItemIcon from "@mui/material/ListItemIcon";
import {SvgIcon} from "@mui/material";
import ListItemText from "@mui/material/ListItemText";
import ListItem from "@mui/material/ListItem";
import {OverridableComponent} from "@mui/material/OverridableComponent";
import {SvgIconTypeMap} from "@mui/material/SvgIcon/SvgIcon";

interface MenuItemProps {
    title: string,
    path?: string|null
    isOpen: boolean,
    icon: OverridableComponent<SvgIconTypeMap> & { muiName: string },
    callback?: Function|null
}

const MenuItem: React.FC<MenuItemProps> = (props) => {
    const itemContent =
        <>
            <ListItemIcon
                sx={{
                    minWidth: 0,
                    mr: props.isOpen ? 3 : 'auto',
                    justifyContent: 'center',
                }}
            >
                <SvgIcon component={props.icon}/>
            </ListItemIcon>
            <ListItemText primary={props.title} sx={{opacity: props.isOpen ? 1 : 0}}/>
        </>
    
    return (
        <ListItem key={props.title} disablePadding sx={{display: 'block'}}>
            {
                props.path && <ListItemButton component={Link} to={props.path}>
                    {itemContent}
                </ListItemButton>
            }
            {
                props.callback && <ListItemButton onClick={function (e) {
                    if (props.callback) {
                        props.callback();
                    }
                }}>
                {itemContent}
                </ListItemButton>
            }
        </ListItem>
    );
};

export default MenuItem;