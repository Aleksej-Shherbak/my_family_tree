import React, {useEffect} from 'react';
import {useDispatch, useSelector} from "react-redux";
import {ThunkDispatch} from "redux-thunk";
import {TreeState} from "../../redux/tree/TreeReducer";
import {TreeAction} from "../../redux/tree/TreeTypes";
import {treeActions} from "../../redux/tree/TreeActions";
import {IAppState} from "../../redux/AppStateTypes";

const FamilyTreeList: React.FC = () => {
    const dispatch: ThunkDispatch<TreeState, any, TreeAction> = useDispatch();
    const treeState = useSelector<IAppState, TreeState>((state) => {
        return state.trees;
    });

    useEffect(() => {
        (async () => await dispatch(treeActions.treeFetchList()))()
    }, []);
    
    return (
        <div>
            {treeState.trees.map(({title, id}) => <div key={id}>{title}</div>)}
        </div>
    );
};

export default FamilyTreeList;