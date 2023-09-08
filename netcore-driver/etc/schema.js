({
    "title": "opcda",
    "key": "opcda",
    "model": {
        "properties": {
            "settings": {
                "title": "设备配置",
                "type": "object",
                "properties": {
                    "interval": {
                        "type": "number",
                        "title": "采集周期"
                    },
                    "port": {
                        "type": "number",
                        "title": "端口"
                    }
                }
            },
            "tags": {
                "title": "数据点",
                "type": "array",
                "items": {
                    "type": "object",
                    "properties": {
                        "name": {
                            "type": "string",
                            "title": "名称"
                        },
                        "id": {
                            "type": "string",
                            "title": "标识"
                        },
                        "unit": {
                            "type": "string",
                            "title": "单位"
                        },
                        "fixed": {
                            "type": "number",
                            "title": "小数位数"
                        },
                        "mod": {
                            "type": "number",
                            "title": "缩放比例"
                        }
                    }
                }
            },
            "commands": {
                "title": "命令",
                "type": "array",
                "items": {
                    "type": "object",
                    "properties": {
                        "name": {
                            "type": "string",
                            "title": "名称"
                        },
                        "form": {
                            "type": "array",
                            "title": "表单项",
                            "items": {
                                "type": "object",
                                "properties": {
                                    "name": {
                                        "type": "string",
                                        "title": "参数名"
                                    },
                                    "type": {
                                        "type": "string",
                                        "title": "数据类型",
                                        "enum": [
                                            "string",
                                            "number",
                                            "boolean"
                                        ],
                                        "enum_title": [
                                            "字符串",
                                            "数字",
                                            "布尔型"
                                        ]
                                    },
                                    "format": {
                                        "type": "string",
                                        "title": "表单类型",
                                        "enum": [
                                            "",
                                            "date",
                                            "datetime",
                                            "email",
                                            "upload_file_input"
                                        ],
                                        "enum_title": [
                                            "默认",
                                            "日期选择器",
                                            "时间选择器",
                                            "电子邮件输入框",
                                            "文件上传"
                                        ]
                                    },
                                    "enum": {
                                        "type": "array",
                                        "title": "选择项值",
                                        "items": {
                                            "type": "string"
                                        }
                                    },
                                    "enum_title": {
                                        "type": "array",
                                        "title": "选择项文字",
                                        "items": {
                                            "type": "string"
                                        }
                                    },
                                    "required": {
                                        "type": "boolean",
                                        "title": "是否必填"
                                    },
                                    "default": {
                                        "type": "string",
                                        "title": "默认值"
                                    },
                                    "mod": {
                                        "type": "number",
                                        "title": "缩放比例"
                                    },
                                    "tagValue": {
                                        "type": "object",
                                        "title": "数值定义",
                                        "properties": {
                                            "minValue": {
                                                "title": "最小值",
                                                "type": "number"
                                            },
                                            "maxValue": {
                                                "title": "最大值",
                                                "type": "number"
                                            },
                                            "minRaw": {
                                                "title": "原始最小值",
                                                "type": "number"
                                            },
                                            "maxRaw": {
                                                "title": "原始最大值",
                                                "type": "number"
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        "ops": {
                            "title": "指令",
                            "type": "array",
                            "items": {
                                "type": "object",
                                "properties": {
                                    "action": {
                                        "type": "string",
                                        "title": "布/撤防",
                                        "enum": [
                                            "arming",
                                            "unArming",
                                            "queryState"
                                        ],
                                        "enum_title": [
                                            "系统全布防",
                                            "系统全撤防",
                                            "查询模块状态"
                                        ]
                                    },
                                    "modelNo": {
                                        "type": "number",
                                        "title": "模块编号",
                                        "description": "查询模块状态指令填写"
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    },
    "device": {
        "properties": {
            "settings": {
                "title": "设备配置",
                "type": "object",
                "properties": {
                    "interval": {
                        "type": "number",
                        "title": "采集周期"
                    }
                }
            },
            "tags": {
                "title": "数据点",
                "type": "array",
                "items": {
                    "type": "object",
                    "properties": {
                        "name": {
                            "type": "string",
                            "title": "名称"
                        },
                        "id": {
                            "type": "string",
                            "title": "标识"
                        },
                        "unit": {
                            "type": "string",
                            "title": "单位"
                        },
                        "fixed": {
                            "type": "number",
                            "title": "小数位数"
                        },
                        "mod": {
                            "type": "number",
                            "title": "缩放比例"
                        }
                    }
                }
            }
        }
    }
})
