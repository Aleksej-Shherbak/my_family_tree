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
import {Link} from "react-router-dom";
import styles from './MainLayout.module.scss';
import {AppBar, Drawer} from "@mui/material";
import {FC} from "react";
import IChildrenContainer from "../../infrastructure/IChildrenContainer";
import MenuItems from "../../components/Menu/MenuItems";
import {useAuthenticated} from "../../hooks/useAuthenticated";
import AlertComponent from "../../components/Alert/AlertComponent";


const MainLayout: FC<IChildrenContainer> = ({children}) => {
    useAuthenticated();
    const [open, setOpen] = React.useState(false);

    const handleDrawerOpen = () => {
        setOpen(true);
    };

    const handleDrawerClose = () => {
        setOpen(false);
    };

    return (
        <Box className={styles.mainContent}>
            <AlertComponent/>
            <CssBaseline/>
            <AppBar className={open ? `${styles.appBar} ${styles.appBarOpened}` : styles.appBar}>
                <Toolbar>
                    <IconButton
                        color="inherit"
                        aria-label="open drawer"
                        onClick={handleDrawerOpen}
                        edge="start"
                        className={styles.openDrawerIconButton}
                        sx={{
                            ...(open && {display: 'none'}),
                        }}
                    >
                        <MenuIcon/>
                    </IconButton>
                    <Link to="/">
                        <Box component="img" src="logo.png" alt="My Family Tree logo" className={styles.logo}/>
                    </Link>
                    <Typography variant="h6" noWrap component="div">
                        MY FAMILY TREE
                    </Typography>
                </Toolbar>
            </AppBar>
            <Drawer
                className={open ? `${styles.menuDrawer} ${styles.menuDrawerOpen}`  : `${styles.menuDrawer} ${styles.menuDrawerClosed}`}
                variant="permanent" open={open}>
                <div className={styles.menuDrawerHead}>
                    <IconButton onClick={handleDrawerClose}>
                        <ChevronLeftIcon/>
                    </IconButton>
                </div>
                <Divider/>
                <List className={open ? styles.menuDrawerOpen  : styles.menuDrawerClosed}>
                    <MenuItems open={open}/>
                </List>

            </Drawer>
            <Box component="main" className={styles.contentWrapper}>
                {children}
            </Box>
        </Box>
    );
}

export default MainLayout;