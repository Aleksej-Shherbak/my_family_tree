import Home from "../pages/Home";
import AccountSettings from "../pages/AccountSettings";
import Register from "../pages/Register";
import ManageAccountsIcon from "@mui/icons-material/ManageAccounts";
import AccountTreeIcon from "@mui/icons-material/AccountTree";
import AddIcon from '@mui/icons-material/Add';
import {OverridableComponent} from "@mui/material/OverridableComponent";
import {SvgIconTypeMap} from "@mui/material/SvgIcon/SvgIcon";
import Login from "../pages/Login";
import EditTree from "../pages/tree/EditTree";
import TreeDetail from "../pages/tree/TreeDetail";

interface IRouterSideMenuItem extends IRouterItem {
    icon: OverridableComponent<SvgIconTypeMap> & { muiName: string },
    title: string,
}

interface IRouterItem {
    name: string,
    path: string,
    isPrivate?: boolean,
    component: JSX.Element,
}

export const routeNames = {
    home: 'home',
    accountSettings: 'account-settings',
    login: 'login',
    logout: 'logout',
    register: 'register',
    
    createNewTree: 'create-new-tree',
    treeDetail: 'tree-detail'
}

export const sideBarMenuRoutes: IRouterSideMenuItem[] = [
    {
        path: '/tree-create',
        component: <EditTree/>,
        name: routeNames.createNewTree,
        title: 'Create new tree',
        icon: AddIcon,
        isPrivate: true
    },
    {
        path: '/',
        component: <Home/>,
        name: routeNames.home,
        title: 'Tree',
        icon: AccountTreeIcon,
        isPrivate: true

    },
    {
        path: '/account-settings',
        component: <AccountSettings/>,
        name: routeNames.accountSettings,
        title: 'Account settings',
        icon: ManageAccountsIcon,
        isPrivate: true
    },
];

export const routes: IRouterItem[] = [
    {path: '/login', component: <Login/>, name: routeNames.login},
    {path: '/register', component: <Register/>, name: routeNames.register},
    {path: 'tree/:id', component: <TreeDetail/>, name: routeNames.treeDetail}
];


export interface IGetRouterPathByNameParamItem {
    name: string,
    value: string
}

export const getRoutePathByName = (routeName: string, params?: IGetRouterPathByNameParamItem[] ): string => {
    const res = [...sideBarMenuRoutes, ...routes].find(({name}) => name === routeName);
    if (res === undefined) {
        return ''
    }
    let path = res.path; 
    if (params) {
        for (const param of params) {
            path = res.path.replace(`:${param.name}`, param.value) 
        }
    }
    return path;
}; 