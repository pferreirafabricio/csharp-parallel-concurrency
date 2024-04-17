# ⚡ Parallelism and concurrency | Conceptual Background

Concurrency includes parallelism.
If two tasks are parallel they're also concurrent.
However, not all concurrent tasks are done in parallel.

> Credits: <https://stackoverflow.com/a/1050257/12542704>
>
> Concurrency is when two or more tasks can start, run, and complete in overlapping time periods. It doesn't necessarily mean they'll ever both be running at the same instant. For example, multitasking on a single-core machine.
>
> Parallelism is when tasks run at the same time, e.g., on a multicore processor.

## Async and Parallelism

Two things are happening at the same instant in time.
Typically this requires some kind of hardware support.

TASK 1 |------|     (Core 1)

&nbsp;&nbsp;TASK 2   |------|   (Core 2)

### Examples

#### Example: 1 CPU with 2 processors

- Starting a program is the same as starting a process
- Inside a process, a thread is started
- Process memory is isolated from each other
- Threads can access the memory of the same process
- Process are distributed by the CPUs
- The OS Scheduler manages the processes

#### Example: Heavy calculation (game, CPU, GPU, mathematical calculation)

- Parallel programming = CPU-bound stuff happening at same point in time
- Threads are executed on the CPU
- For parallel programming, you need multiple CPU cores
- For Async programming, you do not need multiple CPU cores

#### Example: Computer with a single core

- Most of the computers on the cloud use a single core, and most of them are Virtual Machine

#### Example: Windows application in a computer with only 1 core

- Draws an image in the UI
- Situation 1: The app makes a query to the database
  - it will take some amount of time
  - the thread will actively wait, it will block the CPU (ex: stares at the cloak) until the database returns the query
  - the app will be frozen
- Situation 2: The app makes a query to the database
  - the code will be async
  - we let the database do the job in the background
    - something else is busy, not the CPU (the disk, the network, the database, etc)
  - from the point the view of the CPU we are free (ex: set an alarm timer)
  - at some point in time the database will return and trigger the code to process
  - *tasks are not CPU bound

#### Study case: JavaScript

- single core and single thread
- does not support parallel programming natively
- one of the best languages when comes to async programming

#### Study case: C\#

- support parallel and async programming

#### Example: web server with 2 CPUs

- The server is (probably) a single process with a thread pool (free and idle threads)
  - by default, the number of threads in the pool is equal to the number of CPU cores (ex: t1 and t2)
  - *threads are heavy, and use a pretty amount of memory
  - the thread pool can not grow indefinitely
    - try to keep the number of threads small

##### Not async

- Users send an HTTP GET Request to get a video
  - a thread is assigned to the HTTP request (ex: t1) from the thread pools (when the thread is assigned it no longer will be free and available at the thread pool)
  - the code tries to get the image from the disk
  - when we get multiple requests, from 2 or more clients it will be a problem because we have limited CPUs so these threads keep waiting

##### Async

- Users send an HTTP GET Request to get a video
  - thread 1 will locked for a short time, just to "ask" the DB for the video
  - then the thread will right back to the thread pool
  - with that, we can handle way more work
  - when the response is ready it is sent back to the client
  - with 1 thread we can process multiple HTTP requests

> Asynchronous programming is always used when you do non-CPU bound work, like a Database, a file server, a network, etc.

## Concurrency

Start and to their work and end in overlapping periods of time.

TASK 1 start ------- end

&nbsp;&nbsp;&nbsp;TASK 2   start ------ end

### Example: Processor with only 1 core

The operating system will set timers and every time the timer fires they quickly switch tasks.
A little bit of work in each task.
The processor is jumping from one task to another quickly.
It's actually sequential but just chopping it into little blocks
