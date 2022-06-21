import React, {FC} from 'react';
import {Button, Card, CardActions, CardContent, Typography} from "@mui/material";

interface FamilyTreeItemProps {
    title: string,
    description: string,
}

const FamilyTreeItem: FC<FamilyTreeItemProps> = (props) => {
    return (
        <Card variant="outlined">
            <CardContent>
                <Typography sx={{ fontSize: 14 }} color="text.secondary" gutterBottom>
                    {props.title}
                </Typography>
                <Typography variant="body2">{props.description}</Typography>
            </CardContent>
            <CardActions>
                <Button size="small">Open</Button>
            </CardActions>
        </Card>
    );};

export default FamilyTreeItem;