import * as React from 'react';
import {Provider} from "react-redux";
import {store} from "./redux/RootReducer";
import Main from "./Main";

export const App: React.FC = () => 
    <Provider store={store}>
        <Main/>
    </Provider>