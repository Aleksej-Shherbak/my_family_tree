import * as React from 'react';
import {FC} from 'react';
import styles from './NotAuthorizedLayout.module.scss';
import IChildrenContainer from "../../infrastructure/IChildrenContainer";
import AlertComponent from "../../components/Alert/AlertComponent";

const NotAuthorizedLayout: FC<IChildrenContainer> = ({children}) => {
    return (
        <div>
            <AlertComponent/>
            <div className={styles.notAuthorizedLayout}>
                {children}
            </div>    
        </div>
        
    );
};

export default NotAuthorizedLayout;