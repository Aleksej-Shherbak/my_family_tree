import React, {useEffect} from 'react';
import {useDispatch, useSelector} from "react-redux";
import {ThunkDispatch} from "redux-thunk";
import {TreeState} from "../../redux/tree/TreeReducer";
import {TreeAction} from "../../redux/tree/TreeTypes";
import {treeActions} from "../../redux/tree/TreeActions";
import {IAppState} from "../../redux/AppStateTypes";
import {Grid, Typography} from "@mui/material";
import FamilyTreeItem from "./FamilyTreeItem";
import {Link} from "react-router-dom";
import {getRoutePathByName, routeNames} from "../../router/routes";

const FamilyTreeList: React.FC = () => {
    const dispatch: ThunkDispatch<TreeState, any, TreeAction> = useDispatch();
    const treeState = useSelector<IAppState, TreeState>((state) => {
        return state.trees;
    });

    useEffect(() => {
        (async () => await dispatch(treeActions.treeFetchList()))()
    }, []);
    
    const treesElements = treeState.trees?.map(({ id, title, description}) =>
        <Grid item xs={6} sm={4} md={3} lg={3} xl={3}>
            <FamilyTreeItem key={id} title={title} description={description}/>
        </Grid>);

    return (
        <Grid container spacing={1}>
            {
                !treeState.trees || treeState.trees.length > 0 ?
                    <Typography sx={{ fontSize: 14 }} color="text.secondary" gutterBottom>
                        You don't have trees yet. Create your first one 
                        <Link to={getRoutePathByName(routeNames.createNewTree)}>Create your first tree...</Link>
                    </Typography>
                    : 
                    treesElements
            }
        </Grid>
    );
};

export default FamilyTreeList;