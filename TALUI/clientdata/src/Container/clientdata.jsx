import React, { Component, Fragment } from 'react';
import ClientTable from '../Components/clientdata'
import AppBar from '../CommonUI/appbar'


class mainscreen extends Component {
    render() {
        return (

            <Fragment>
                <AppBar></AppBar>
                <div style={{ marginLeft: '5%', marginRight: '5%', marginTop: '2%', marginBottom: '2%' }}>
                    <ClientTable></ClientTable>
                </div>
                <div>New TEst button</div>
                <div>Client form with save button</div>
            </Fragment>

        )
    }
}

export default mainscreen;