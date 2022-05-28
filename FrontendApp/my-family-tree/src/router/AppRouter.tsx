import * as React from 'react';
import {Route, Routes} from "react-router-dom";
import {privateRoutes/*, publicRoutes*/} from "./routes";

const AppRouter = () => {
    return (
        <div>
            <Routes>
                {
                    [/*...publicRoutes,*/ ...privateRoutes]
                        .map(({ path, component }) =>
                            <Route path={path} key={path} element={component()} />
                        )
                }
            </Routes>
        </div>
    );
};

export default AppRouter;