import * as React from 'react';
import {FC} from 'react';
import './NotAuthorizedLayout.scss';
import IChildrenContainer from "../../infrastructure/IChildrenContainer";

const NotAuthorizedLayout: FC<IChildrenContainer> = ({children}) => {
    return (
        <div className="NotAuthorizedLayout">
            {children}
        </div>
    );
};

export default NotAuthorizedLayout;