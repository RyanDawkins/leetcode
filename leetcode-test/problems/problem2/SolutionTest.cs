using System;
using System.Diagnostics;
using System.Text;
using leetcode.problems.program2;
using Xunit;
using Xunit.Abstractions;

namespace leetcode_test.problems.program2
{
    public class SolutionTest
    {

        private readonly Solution _solution;
        private readonly ITestOutputHelper _outputHelper;

        public SolutionTest(ITestOutputHelper outputHelper) {
            _solution = new Solution();
            _outputHelper = outputHelper;
        }

        /// <summary>
        /// Most basic test case given
        /// </summary>
        [Fact]
        public void TestCase1()
        {
            ListNode l1 = new ListNode(2) {
                next = new ListNode(4) {
                    next = new ListNode(3)
                }
            };
            ListNode l2 = new ListNode(5) {
                next = new ListNode(6) {
                    next = new ListNode(4)
                }
            };

            ListNode expected = new ListNode(7) {
                next = new ListNode(0) {
                    next = new ListNode(8)
                }
            };

            ListNode actual = _solution.AddTwoNumbers(l1, l2);

            Print(expected);
            Print(actual);
            AssertAreEqual(expected, actual);
        }

        [Fact]
        public void TestCase_Zero()
        {
            ListNode l1 = new ListNode(0);
            ListNode l2 = new ListNode(0);

            ListNode expected = new ListNode(0);
            ListNode actual = _solution.AddTwoNumbers(l1, l2);

            Print(expected);
            Print(actual);
            AssertAreEqual(l1, l2);
        }

        [Fact]
        public void TestCase_Overflow()
        {
            ListNode l1 = new ListNode(9);
            ListNode l2 = new ListNode(1) {
                next = new ListNode(9) {
                    next = new ListNode(9) {
                        next = new ListNode(9) {
                            next = new ListNode(9) {
                                next = new ListNode(9) {
                                    next = new ListNode(9) {
                                        next = new ListNode(9) {
                                            next = new ListNode(9) {
                                                next = new ListNode(9)
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            ListNode expected = new ListNode(0) {
                next = new ListNode(0) {
                    next = new ListNode(0) {
                        next = new ListNode(0) {
                            next = new ListNode(0) {
                                next = new ListNode(0) {
                                    next = new ListNode(0) {
                                        next = new ListNode(0) {
                                            next = new ListNode(0) {
                                                next = new ListNode(0) {
                                                    next = new ListNode(1)
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
            
            ListNode actual = _solution.AddTwoNumbers(l1, l2);

            Print(expected);
            Print(actual);
            AssertAreEqual(expected, actual);
        }

        private void Print(ListNode node, StringBuilder buffer = null)
        {
            if(buffer == null) {
                buffer = new StringBuilder();
            }

            if(node == null) {
                _outputHelper.WriteLine(buffer.ToString());
                return;
            }
            buffer.Append(node.val);
            if(node.next != null) {
                buffer.Append(" ->");
            }

            Print(node.next, buffer);
        }

        private void AssertAreEqual(ListNode expected, ListNode actual)
        {
            if(expected == null && actual == null) {
                return;
            }

            Assert.Equal(expected.val, actual.val);
            AssertAreEqual(expected.next, actual.next);
        }

    }

}