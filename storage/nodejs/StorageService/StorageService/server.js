'use strict';

const storage = require('azure-storage');
const service = storage.createBlobService('DefaultEndpointsProtocol=https;AccountName=data203;AccountKey=wuYWMO76VzTuTI2I5aRzCABPtUFlLpRGg+Xgc7sLpDxObcauuz3yW/SVY329+dMTKOxrvAFupk1g+zgFP9056A==;EndpointSuffix=core.windows.net');
const blobName = 'blob1';
const containerName = 'container';
const fileName = 'data.txt';


const getBlob = (containerName, blobName) => {
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

const createBlob = (containerName,blobName,fileName) => {
    service.createContainerIfNotExists(containerName,err => {
        if(err)
            console.log(err);
    });

    service.createPageBlobFromLocalFile(containerName,blobName,fileName,(err,result) =>{
        if(err)
            console.log(err);
        else
            console.dir(result, { depth: null, colors: true });
    });
}

createBlob(containerName,blobName,fileName);
//getBlob(containerName, blobName);
//deleteBlob(containerName, blobName);