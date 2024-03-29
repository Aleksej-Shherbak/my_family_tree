import React, {useEffect} from 'react';
import {BrowserRouter} from "react-router-dom";
import AppRouter from "./router/AppRouter";
import {AppDispatch} from "./redux/RootReducer";
import {useDispatch} from "react-redux";
import {treeActions} from "./redux/tree/TreeActions";
import {personActions} from "./redux/person/PersonActions";

const Main: React.FC = () => {
    const dispatch: AppDispatch = useDispatch();

    useEffect(() => {
        (async () => {
            // INITIALIZE ALL GLOBAL AND DEFAULT DATA HERE
            await dispatch(treeActions.treeFetchList());
            await dispatch(personActions.fetchList());
        })()
    }, []);
    
    return (
        <>
            <BrowserRouter>
                <AppRouter/>
            </BrowserRouter>
        </>
    );
};

export default Main;