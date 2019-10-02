'use strict';
var http = require('http');
var port = process.env.PORT || 3000;

const path = require('path');
const storage = require('azure-storage');
const service = storage.createBlobService('DefaultEndpointsProtocol=https;AccountName=data203;AccountKey=wuYWMO76VzTuTI2I5aRzCABPtUFlLpRGg+Xgc7sLpDxObcauuz3yW/SVY329+dMTKOxrvAFupk1g+zgFP9056A==;EndpointSuffix=core.windows.net');

const blobName = 'blob1';
const containerName = 'container';


const download = (containerName, blobName) => {
    service.getBlobToText(containerName, blobName, (err, data) => {
        if (err)
            console.log(err);
        else
            console.log(data);
    });
}

const deleteBlob = (containerName, blobName) => {
    service.deleteBlobIfExists(containerName, blobName, err => {
        if (err)
            console.log(err);
        else
            console.log('delete blobl :' + blobName);
    });
}

//download(containerName, blobName);
deleteBlob(containerName, blobName);