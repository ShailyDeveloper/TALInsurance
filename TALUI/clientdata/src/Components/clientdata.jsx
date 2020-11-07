import React, { Component, Fragment } from 'react';
import { withStyles } from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';
import axios from 'axios';

const StyledTableCell = withStyles((theme) => ({
    head: {
        backgroundColor: theme.palette.common.black,
        color: theme.palette.common.white,
    },
    body: {
        fontSize: 14,
    },
}))(TableCell);

const StyledTableRow = withStyles((theme) => ({
    root: {
        '&:nth-of-type(odd)': {
            backgroundColor: theme.palette.action.hover,
        },
    },
}))(TableRow);

class clientdata extends Component {
    state = {
        clientinfo: []
    }
    componentDidMount() {
        axios.get("https://localhost:44324/api/clientdata")
            .then(Response => {
                this.setState({
                    clientinfo: Response.data,
                    loading: false
                });

            }
            ).catch(error => {
                this.setState({
                    loading: false
                });
                console.log(error)
            });
    }
    render() {
        return (
            <Fragment>
                <h1>Client Information</h1>
                <TableContainer component={Paper}>
                    <Table aria-label="customized table">
                        <TableHead>
                            <TableRow>
                                <StyledTableCell>Client Name</StyledTableCell>
                                <StyledTableCell align="right">Age</StyledTableCell>
                                <StyledTableCell align="right">DOB</StyledTableCell>
                                <StyledTableCell align="right">Occupation</StyledTableCell>
                                <StyledTableCell align="right">Sum</StyledTableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {this.state.clientinfo.map(dataval => (
                                <StyledTableRow key={dataval.name}>
                                    <StyledTableCell component="th" scope="row">
                                        {dataval.name}
                                    </StyledTableCell>
                                    <StyledTableCell align="right">{dataval.age}</StyledTableCell>
                                    <StyledTableCell align="right">{dataval.dob}</StyledTableCell>
                                    <StyledTableCell align="right">{dataval.occupation}</StyledTableCell>
                                    <StyledTableCell align="right">{dataval.sumInsured}</StyledTableCell>
                                </StyledTableRow>
                            ))}
                        </TableBody>
                    </Table>
                </TableContainer>
            </Fragment >
        );
    }
}

export default clientdata