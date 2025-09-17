using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Basic priority queue operations
    // Expected Result:  Items are dequeued in order of priority
    // Defect(s) Found: None
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 5);
        priorityQueue.Enqueue("High", 10);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Multiple items with same priority
    // Expected Result: Items with same priority are dequeued in FIFO order
    // Defect(s) Found: Code does not maintain FIFO order for same priority items
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 5);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }
    [TestMethod]
    // Scenario:  Dequeue from empty queue
    // Expected Result: Exception is thrown
    // Defect(s) Found: Code does not throw exception when dequeuing from empty queue
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }
    [TestMethod]
    // Scenario:  Enqueue and Dequeue interleaved  
    // Expected Result: Items are dequeued in correct priority order
    // Defect(s) Found: None
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 5);
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        priorityQueue.Enqueue("High", 10);
        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue one item and dequeue it
    // Expected Result: That item is returned
    // Defect(s) Found: None
    public void TestPriorityQueue_SingleItem()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Solo", 42);
        Assert.AreEqual("Solo", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with negative priority values
    // Expected Result: Highest (least negative) priority item is dequeued first
    // Defect(s) Found: Negative priorities are not handled correctly
    public void TestPriorityQueue_NegativePriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", -10);
        priorityQueue.Enqueue("Medium", -5);
        priorityQueue.Enqueue("High", -1);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

}