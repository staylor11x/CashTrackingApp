# Cash Tracking App

## Purpose of the app

The purpoese of this app is to allow the user to track the comings and goings of their cash supply with a key focus on, simplicty, speed and security.

## What problem is the app solving?

Will allow the user to easily veryify if someone is stealing their cash!! Also allows the user to keep track of their spending.

The app will allow the user to:

- See the current balance of their cash
- Add cash to the current balance
- Withraw cash from their balance
- See their transacion history

## Best Practices

One of the main things focused on in this app was the use of industry best practices for app development these include 

- Unit tesing
- CI/CD
- Design patterns
- DRY principle

## How the app is constructed

### Framework and Code

The app has been built usign the .NET MAUI framework, this was chosen due to it's familiarity and also allowing the app to be developed simultaenously on iOS and Andriod.

### Tetsing 

The code uses the xunit test framwork and both unit and integration tests are being used.

### CI/CD

The code uses github actions for the CI/CD process, ensuring the app builds sucessfully and tests pass in a windows environment. 

Additionally the app is also built in an anrdoid environment and in the future an iOS environment will be included.

### Development Process

The app is being developed using the agile methodology, although this is limited due to being developed by only me! 

Feature branches are used to deliver new content, this keeps the project clean and ensures no bad code is puhsed to the production enviroment.

Making use of user stories and a kanban board to keep track of features and ensure the delivery of the mvp as soon as possible. 

The app is tested is user tested by me for a time period, with the hope of then making the app available on the google play store initially, and then maybe one day on the apple app store.
