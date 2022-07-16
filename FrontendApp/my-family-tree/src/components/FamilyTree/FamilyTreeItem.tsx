import React, {FC} from 'react';
import {Button, Card, CardActions, CardContent, Typography} from "@mui/material";
import {getRoutePathByName, routeNames} from "../../router/routes";

interface FamilyTreeItemProps {
    id: number,
    title: string,
    description: string,
    imageUrl: string|undefined
}

const FamilyTreeItem: FC<FamilyTreeItemProps> = ({id, title, description, imageUrl}) => {
    return (
        <Card variant="outlined">
            <CardContent>
                {
                    imageUrl &&
                    <img alt={title} src={imageUrl} width={200} height={200}/>
                }
                <Typography sx={{ fontSize: 14 }} color="text.secondary" gutterBottom>
                    {title}
                </Typography>
                <Typography variant="body2">{description}</Typography>
            </CardContent>
            <CardActions>
                <Button href={getRoutePathByName(routeNames.treeDetail,
                      [{name: 'id', value: id.toString()}])}>
                    Open
                </Button>
            </CardActions>
        </Card>
    );};

export default FamilyTreeItem;