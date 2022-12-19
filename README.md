# LearnHangfireApp

## How to run

Update Connection string for sql server based on you system config in all application appsettings.json file.
then start all the applications and check the console logs
you can change log level for hangfire in appsettings.json file "Hangfire": "Trace" for more detailed logs from hangfire.
From more details check offical docs https://docs.hangfire.io/en/latest/getting-started/index.html

## How it works
Hangfire use seperate process than running application, but it still use high resource from the system if deployed in same server

When come to scalling, it is not efficent as it use polling which keep on query sql server based on intervel configured (default poll interval is 15 seconds)
hitting sql server constantly will use much server resource and negatively impact application performence.

The better way is to decouple the background logic from application and use rabitmq to process seperatly in different server/container

## So what I learned
Hangfire and RabbitMQ are both tools that can be used for background job processing and message passing, but they have some key differences.

Hangfire is a .NET library that can be used to schedule and execute background jobs in .NET applications. It is designed to be easy to use and integrates seamlessly with .NET applications. But it consume much resorceses.

RabbitMQ, on the other hand, is an open-source message broker that implements the Advanced Message Queuing Protocol (AMQP). It can be used to decouple application components and enable asynchronous communication between them. RabbitMQ is a more general-purpose solution that can be used in a variety of scenarios, including background job processing, but it is not specifically tailored for this use case like Hangfire is and it didn't relay on database server.

In summary, if you are looking for a simple and easy-to-use solution for scheduling and executing background jobs in a .NET application, Hangfire might be a good choice. If you need a more general-purpose message broker for asynchronous communication between components in your system, RabbitMQ might be a better fit.
