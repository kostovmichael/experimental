export function dummyDeferredTask() {
    return new Promise((resolve) => {
        setTimeout(() => {
            resolve("resolved");
        }, 2000);
    });
}

export async function asyncCall() {
    console.log("begin async await call");
    var result = await dummyDeferredTask();
    console.log("end async await call");
    console.log(result);
    return result;
    // expected output: 'resolved'
}
