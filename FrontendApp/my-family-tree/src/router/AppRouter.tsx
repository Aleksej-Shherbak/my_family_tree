import * as React from 'react';
import {Route, Routes} from "react-router-dom";
import {privateRoutes, publicRoutes} from "./routes";

const AppRouter = () => {
    return (
        <>
            <Routes>
                {
                    [...publicRoutes, ...privateRoutes]
                        .map(({path, component}) =>
                            <Route path={path} key={path} element={component()}/>
                        )
                }
            </Routes>
        </>
    );
};

export default AppRouter;