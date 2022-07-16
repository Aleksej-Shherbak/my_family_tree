import React, {useEffect} from 'react';
import {connect, useDispatch} from "react-redux";
import {treeActions} from "../../redux/tree/TreeActions";
import {Grid, Typography} from "@mui/material";
import FamilyTreeItem from "./FamilyTreeItem";
import {Link} from "react-router-dom";
import {getRoutePathByName, routeNames} from "../../router/routes";
import {TreesState} from "../../redux/tree/TreeReducer";
import {IAppState} from "../../redux/AppStateTypes";
import {getFileUrl} from "../../helpers/urlHelpers";

const mapStateToProps = (state: IAppState) => state.trees;

const FamilyTreeList: React.FC<TreesState> = ({trees}) => {
    
    const treesElements = trees?.map(({id, title, description, image}) =>
        <Grid key={id} item xs={6} sm={4} md={3} lg={3} xl={3}>
            {
                image ?
                    <FamilyTreeItem id={id} title={title} imageUrl={getFileUrl(image)} description={description ?? ''}/>
                    :
                    // TODO use default props instead of image={undefined}
                    <FamilyTreeItem id={id} title={title} imageUrl={undefined} description={description ?? ''}/>
            }
        </Grid>);

    return (
        <Grid container spacing={1}>
            {
                !trees || trees.length === 0 ?
                    <Typography sx={{fontSize: 14}} color="text.secondary" gutterBottom>
                        You don't have trees yet. Create your first one
                        <Link style={{marginLeft: '5px'}} to={getRoutePathByName(routeNames.createNewTree)}>Create your
                            first tree</Link>
                    </Typography>
                    :
                    treesElements
            }
        </Grid>
    );
};

export default connect(mapStateToProps)(FamilyTreeList);