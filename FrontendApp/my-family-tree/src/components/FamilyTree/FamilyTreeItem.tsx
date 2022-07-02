import React, {FC} from 'react';
import {Button, Card, CardActions, CardContent, Typography} from "@mui/material";

interface FamilyTreeItemProps {
    title: string,
    description: string,
    imageUrl: string|undefined
}

const FamilyTreeItem: FC<FamilyTreeItemProps> = ({title, description, imageUrl}) => {
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
                <Button size="small">Open</Button>
            </CardActions>
        </Card>
    );};

export default FamilyTreeItem;