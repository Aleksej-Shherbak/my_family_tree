import * as React from 'react';
import {useTheme} from '@mui/material/styles';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import List from '@mui/material/List';
import CssBaseline from '@mui/material/CssBaseline';
import Typography from '@mui/material/Typography';
import Divider from '@mui/material/Divider';
import IconButton from '@mui/material/IconButton';
import MenuIcon from '@mui/icons-material/Menu';
import ChevronLeftIcon from '@mui/icons-material/ChevronLeft';
import ChevronRightIcon from '@mui/icons-material/ChevronRight';
import {Link} from "react-router-dom";
import MenuItems from "../../../components/Menu/MenuItems";
import AppRouter from "../../../router/AppRouter";
import './MainLayout.scss';
import {AppBar, Drawer} from "@mui/material";


export default function MiniDrawer() {
    const theme = useTheme();
    const [open, setOpen] = React.useState(false);
    
    const handleDrawerOpen = () => {
        setOpen(true);
    };

    const handleDrawerClose = () => {
        setOpen(false);
    };

    return (
        <Box sx={{ display: 'flex' }}>
            <CssBaseline />
            <AppBar className={open ? 'app-bar app-bar-opened' : 'app-bar'}>
                <Toolbar>
                    <IconButton
                        color="inherit"
                        aria-label="open drawer"
                        onClick={handleDrawerOpen}
                        edge="start"
                        sx={{
                            marginRight: 5,
                            ...(open && { display: 'none' }),
                        }}
                    >
                        <MenuIcon />
                    </IconButton>
                    <Link to="/">
                        <Box component="img" src="logo.png" alt="My Family Tree logo" sx={{marginRight: 2, marginTop: 1}}/>
                    </Link>
                    <Typography variant="h6" noWrap component="div">
                        MY FAMILY TREE
                    </Typography>
                </Toolbar>
            </AppBar>
            <Drawer className={open ? 'menu-drawer menu-drawer-open' : 'menu-drawer menu-drawer-closed'} variant="permanent" open={open}>
                <div className="drawer-head">
                    <IconButton onClick={handleDrawerClose}>
                        {theme.direction === 'rtl' ? <ChevronRightIcon /> : <ChevronLeftIcon />}
                    </IconButton>
                </div>
                <Divider />
                <List>
                    <MenuItems open={open}/>   
                </List>
                
            </Drawer>
            <Box component="main" className="main-content" sx={{ flexGrow: 1, p: 3 }}>
                <AppRouter/>
            </Box>
        </Box>
    );
}
