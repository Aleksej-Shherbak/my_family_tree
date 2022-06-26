import * as React from 'react';
import {Route, Routes} from "react-router-dom";
import {sideBarMenuRoutes, routes} from "./routes";
import PrivateRoute from "./PrivateRoute";
import Page404 from "../pages/Page404";

const AppRouter = () => {
    return (
        <>
            <Routes>
                {
                    [...routes, ...sideBarMenuRoutes]
                        .map(({path, component, isPrivate}) => {
                                if (isPrivate) {
                                    return <Route key={path} path={path} element={<PrivateRoute outlet={component}/>}/>
                                }
                                return <Route path={path} key={path} element={component}/>
                            }
                        )
                }
                <Route path="*" element={<Page404/>} />
            </Routes>
        </>
    );
};

export default AppRouter;