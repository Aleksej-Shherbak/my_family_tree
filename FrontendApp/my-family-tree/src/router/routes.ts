import Home from "../pages/Home";
import AccountSettings from "../pages/AccountSettings";
import Register from "../pages/Register";
import ManageAccountsIcon from "@mui/icons-material/ManageAccounts";
import AccountTreeIcon from "@mui/icons-material/AccountTree";
import {OverridableComponent} from "@mui/material/OverridableComponent";
import {SvgIconTypeMap} from "@mui/material/SvgIcon/SvgIcon";
import Login from "../pages/Login";

interface IRouterSideMenuItem extends IRouterItem {
    icon: OverridableComponent<SvgIconTypeMap> & { muiName: string },
    title: string,
}

interface IRouterItem {
    name: string,
    path: string,
    component: () => JSX.Element,
}

export const routeNames = {
    home: 'home',
    accountSettings: 'account-settings',
    login: 'login',
    logout: 'logout',
    register: 'register',
}

export const privateRoutes: IRouterSideMenuItem[] = [
    {
        path: '/',
        component: Home,
        name: routeNames.home,
        title: 'Tree',
        icon: AccountTreeIcon
    },
    {
        path: '/account-settings',
        component: AccountSettings,
        name: routeNames.accountSettings,
        title: 'Account settings',
        icon: ManageAccountsIcon
    },
];

export const publicRoutes: IRouterItem[] = [
    {path: '/login', component: Login, name: routeNames.login},
    {path: '/register', component: Register, name: routeNames.register},
];

export const getPathByName = (routeName: string): string => {
    const res = [...privateRoutes, ...publicRoutes].find(({name}) => name === routeName);
    if (res === undefined) {
        return ''
    }
    return res.path;
}; 