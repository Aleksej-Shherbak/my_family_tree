import Home from "../pages/Home";
import AccountSettings from "../pages/AccountSettings";
import Login from "../pages/Login";
import Register from "../pages/Register";
import ManageAccountsIcon from "@mui/icons-material/ManageAccounts";
import AccountTreeIcon from "@mui/icons-material/AccountTree";
import {OverridableComponent} from "@mui/material/OverridableComponent";
import {SvgIconTypeMap} from "@mui/material/SvgIcon/SvgIcon";


interface IRouterItem {
    icon: OverridableComponent<SvgIconTypeMap> & { muiName: string },
    title:string, 
    name:string, 
    path: string,
    component: () => JSX.Element,
}

export const privateRoutes: IRouterItem[] = [
    {
        path: '/',
        component: Home,
        name: 'home',
        title: 'Tree',
        icon: AccountTreeIcon
    },
    {
        path: '/account-settings',
        component: AccountSettings,
        name: 'settings',
        title: 'Account settings',
        icon: ManageAccountsIcon
    },
];

/*
export const publicRoutes: IRouterItem[] = [
    {path: '/login', component: Login, name: 'login'},
    {path: '/register', component: Register, name: 'register'},
];*/

export const getRoutByName = (routeName: string) => privateRoutes.find(({ name }) => name === routeName); 