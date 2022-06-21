import * as React from 'react';
import {Route, Routes} from "react-router-dom";
import {sideBarMenuRoutes, routes} from "./routes";

const AppRouter = () => {
    return (
        <>
            <Routes>
                {
                    [...routes, ...sideBarMenuRoutes]
                        .map(({path, component}) =>
                            <Route path={path} key={path} element={component()}/>
                        )
                }
            </Routes>
        </>
    );
};

export default AppRouter;